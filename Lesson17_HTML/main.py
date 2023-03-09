from flask import Flask, render_template
from LoginForm import Lf

app = Flask(__name__)

app.config['SECRET_KEY'] = 'hello hello hello hello hello world'

@app.route('/')
def main():
    return render_template('base.html')

@app.route('/register', methods=['GET', 'POST'])
def reg():
    form = Lf()
    if form.validate_on_submit():
        pass
    
    return render_template('register.html', title='Регистрация', form = form)


if __name__ == '__main__':
    app.run()
