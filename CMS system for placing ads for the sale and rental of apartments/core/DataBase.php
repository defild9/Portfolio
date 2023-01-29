<?php

namespace core;
use Exception;

/**
 * Клас для виконнаня запитів до бд
*/
class DataBase
{
    protected $pdo;

    public function  __construct($host, $login, $password, $database){
        $this->pdo = new \PDO("mysql:host={$host};dbname={$database}",$login,$password);
    }

    /**
     * Вибиріка данних з бази данних
     * @param string $tableName Назва таблиці бази даних
     * @param string|array $fieldsList Список полів
     * @param array|null $conditionArray Список умов для пошуку
     * @return array|false
     */
    public function select($tableName, $fieldsList = "*", $conditionArray = null) {
        if (is_string($fieldsList))
            $fieldsListString = $fieldsList;
        if (is_array($fieldsList))
            $fieldsListString = implode(', ', $fieldsList);
        $wherePartString = "";
        if (is_array($conditionArray)) {
            $parts = [];
            foreach ($conditionArray as $key => $value) {
                $parts [] = "{$key} = :{$key}";
            }
            $wherePartString = "WHERE ".implode(' AND ', $parts);
        }
        $res = $this->pdo->prepare("SELECT {$fieldsListString} FROM {$tableName} {$wherePartString}");
        $res->execute($conditionArray);
        return $res->fetchAll(\PDO::FETCH_ASSOC);
    }

    public function update($tableName, $newValuesArray, $conditionArray) {
        $setParts = [];
        $paramsArray = [];
        foreach ($newValuesArray as $key => $value) {
            $setParts [] = "{$key} = :set{$key}";
            $paramsArray['set'.$key] = $value;
        }
        $setPartString = implode(', ', $setParts);

        $whereParts = [];
        foreach ($conditionArray as $key => $value) {
            $whereParts [] = "{$key} = :{$key}";
            $paramsArray[$key] = $value;
        }
        $wherePartString = "WHERE ".implode(' AND ', $whereParts);
        $res = $this->pdo->prepare("UPDATE {$tableName} SET {$setPartString} {$wherePartString}");
        $res->execute($paramsArray);
    }
    public function insert($tableName, $newRowArray) {
        $fieldsArray = array_keys($newRowArray);
        $fieldsListString = implode(', ', $fieldsArray);
        $paramsArray = [];
        foreach ($newRowArray as $key => $value) {
            $paramsArray [] = ':'.$key;
        }
        $valuesListString = implode(', ', $paramsArray);
        $res = $this->pdo->prepare("INSERT INTO {$tableName} ($fieldsListString) VALUES($valuesListString)");
        $res->execute($newRowArray);
    }
    public function delete($tableName, $conditionArray) {
        $whereParts = [];
        foreach ($conditionArray as $key => $value) {
            $whereParts [] = "{$key} = :{$key}";
            $paramsArray[$key] = $value;
        }
        $wherePartString = "WHERE ".implode(' AND ', $whereParts);
        $res = $this->pdo->prepare("DELETE FROM {$tableName} {$wherePartString}");
        $res->execute($conditionArray);
    }

    public function selectWithJoin($tableNameFirst,$tableNameSecond, $fieldsList = "*", $conditionArray = null, $keyFirst, $keySecond){
        if (is_string($fieldsList))
            $fieldsListString = $fieldsList;
        if (is_array($fieldsList))
            $fieldsListString = implode(', ', $fieldsList);
        $wherePartString = '';
        if (is_array($conditionArray)) {
            $parts = [];
            foreach ($conditionArray as $key => $value) {
                $parts [] = "{$key} = :{$key}";
            }
            $wherePartString = "WHERE ".implode(' AND ', $parts);
        }
        $res = $this->pdo->prepare("SELECT {$fieldsListString} FROM {$tableNameFirst} INNER JOIN {$tableNameSecond} ON {$tableNameFirst}.{$keyFirst} = {$tableNameSecond}.{$keySecond} {$wherePartString}");
        $res->execute($conditionArray);
        return $res->fetchAll(\PDO::FETCH_ASSOC);
    }

    protected function generateWhere($conditionArray){
        $whereParts = [];
        foreach ($conditionArray as $key => $value) {
            $whereParts [] = "{$key} = :{$key}";
            $paramsArray[$key] = $value;
        }
        $wherePartString = "WHERE ".implode(' AND ', $whereParts);
        return $wherePartString;
    }

    public function transactionInsert($firstTableName, $firstRowArray, $secondTableName, $secondRowArray){
        try{
            $this->pdo->beginTransaction();
            //adress
            $this->insert($firstTableName,$firstRowArray);
            //house
            $secondRowArray['id_adress'] = $this->pdo->lastInsertId($firstTableName);
            $this->insert($secondTableName, $secondRowArray);
            $this->pdo->commit();
        }catch (Exception $e){
            $this->pdo->rollBack();
            echo "{$e}";
        }
        
    }
    public function transactionDelete($firstTableName, $firstConditionArray, $id, $secondTableName){
        try{
            $this->pdo->beginTransaction();
            $idForSecondTable = $this->select($firstTableName,['id_adress'],[
                'id_house' => $id
            ]);
            $idFinedArr = [];
            foreach ($idForSecondTable[0] as $key => $value){
                array_push($idFinedArr, $value);
            }
            $this->delete($firstTableName, $firstConditionArray);
            $this->delete($secondTableName, [
                'id_adress'=> intval($idFinedArr[0])
            ]);
            $this->pdo->commit();
        }catch (Exception $exception){
            $this->pdo->rollBack();
            echo "{$exception}";
        }
    }
    public function transactionUpdate($firstTableName,$newFirstValuesArray, $firstConditionArray, $id, $secondTableName, $newSecondValuesArray){
        try{
            $this->pdo->beginTransaction();
            $idForSecondTable = $this->select($firstTableName,['id_adress'],[
                'id_house' => $id
            ]);
            $idFinedArr = [];
            foreach ($idForSecondTable[0] as $key => $value){
                array_push($idFinedArr, $value);
            }
            $secondConditionArray = [
                'id_adress' => intval($idFinedArr[0])
            ];
            $this->update($firstTableName,$newFirstValuesArray, $firstConditionArray);
            $this->update($secondTableName,$newSecondValuesArray,$secondConditionArray);
            $this->pdo->commit();
        }catch (Exception $exception){
            $this->pdo->rollBack();
            echo $exception;
        }
    }
    //SELECT * FROM House ORDER BY date_of_create DESC;
    public function selectWithSort($tableName, $fieldsList = "*", $conditionArray = null, $groupByFild, $sortType ='DESC') {
        if (is_string($fieldsList))
            $fieldsListString = $fieldsList;
        if (is_array($fieldsList))
            $fieldsListString = implode(', ', $fieldsList);
        $wherePartString = "";
        if (is_array($conditionArray)) {
            $parts = [];
            foreach ($conditionArray as $key => $value) {
                $parts [] = "{$key} = :{$key}";
            }
            $wherePartString = "WHERE ".implode(' AND ', $parts);
        }
        $res = $this->pdo->prepare("SELECT {$fieldsListString} FROM {$tableName} {$wherePartString} ORDER BY {$groupByFild} {$sortType}");
        $res->execute($conditionArray);
        return $res->fetchAll(\PDO::FETCH_ASSOC);
    }
}
