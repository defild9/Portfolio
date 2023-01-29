import requests
from config import Telegram_Token
from aiogram import Bot, types
from aiogram.dispatcher import Dispatcher
from aiogram.utils import executor


bot = Bot(token=Telegram_Token)
dp = Dispatcher(bot)

@dp.message_handler(commands=['start'])
async def start_command(message: types.Message):
    await message.reply("Привет, я бот который покажет информацию о крипте которая тебе интересна")

@dp.message_handler()
async def get_crypto_info(message: types.Message):
    try:
        r = requests.get(f"https://data.messari.io/api/v1/assets/{message.text}/metrics")
        data = r.json()

        #requests from messari.io
        name_of_crypto = data['data']['name']
        price = data['data']['market_data']['price_usd']
        slug = data['data']['slug']
        all_time_high_price = data['data']['all_time_high']['price']
        percent_change_usd_last_1_hour = data['data']['market_data']['percent_change_usd_last_1_hour']
        percent_change_usd_last_24_hours = data['data']['market_data']['percent_change_usd_last_24_hours']
        await message.answer(f"Информация о {name_of_crypto}:\n<b>Цена:</b> {round(price,2)}"
                             f"\n<b>Самая максмисальная цена за все время:</b> {round(all_time_high_price,2)}"
                             f"\n<b>Процент изменения за последний час:</b> {round(percent_change_usd_last_1_hour,2)}%",
                             parse_mode=types.ParseMode.HTML)


        # #requests from coinmarketcap.com
        # try:
        #     r2 = requests.get(f"https://api.coingecko.com/api/v3/coins/{slug}/tickers")
        #     data2 = r2.json()
        #     market_name = []
        #     market_link = []
        #     answer_message_text = ""
        #     # for tickers in data2['tickers']:
        #     #     market_name.append(tickers['market']['name'])
        #     #     market_link.append(tickers['trade_url'])
        #     #
        #     # for i in range(len(market_name)):
        #     #     await message.answer(f"{market_name[i]} - {market_link}\n")
        #
        #     for tickers in data2['tickers']:
        #         answer_message_text += f"{tickers['market']['name']} - {tickers['trade_url']}\n"
        #     await message.answer(answer_message_text)
        #
        # except Exception as e:
        #     print(e)
        #     await  message.reply("Извините, но у нас нет информации о биржах где есть эта криптовалюта 😥")

    except Exception as ex:
        print(ex)
        await message.reply("Проверте названые криптовалюты")

if __name__ == '__main__':
    executor.start_polling(dp)