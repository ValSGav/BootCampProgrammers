from flask import Flask

app = Flask(__name__)

@app.route('/')
def main():
    return 'Hello there <a href = "/index">Перейти на следующую страницу</a>'

@app.route('/index/<x>/<y>')
def index(x, y):
    return 'Hello world' + x + y

if __name__ == '__main__':
    app.run()