from flask import Flask, render_template

app = Flask(__name__)

@app.route('/')
def main():
    with open('file.txt', 'r', encoding='utf-8') as file:

        resultlist = list()
        for line in file.readlines():
            resultlist.append(tuple(line.split('\n')[0].split(';')))

    return render_template('base.html', data= resultlist)

@app.route('/about')
def about():
    return render_template('about.html')

if __name__ == '__main__':
    app.run()