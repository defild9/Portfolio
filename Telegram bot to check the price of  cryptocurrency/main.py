import requests
from pprint import pprint
from  array import *
from config import Telegram_Token
from math import *

def get_price(name_of_crypto):
    try:
        r = requests.get(f"https://data.messari.io/api/v1/assets/{name_of_crypto}/metrics")
        data = r.json()
        pprint(data)

        name_of_crypto = data['data']['name']
        price = data['data']['market_data']['price_usd']
        slug = data['data']['slug']

        r2 = requests.get(f"https://api.coingecko.com/api/v3/coins/{slug}/tickers")
        data2 = r2.json()
        #pprint(data2)

        #print(f"Цена криптовалюты {name_of_crypto} составляет {round(price,2)} долларов США и её символьный код {slug}\n")
        #биржы
        market_name = []
        market_link = []


        #биржи




    except Exception as ex:
        print(ex)
        print("Проверте названые криптовалюты")
def main():
    name_of_crypto = input("Введите название криптовалюты: ")
    get_price(name_of_crypto)

if __name__ == '__main__':
    main()