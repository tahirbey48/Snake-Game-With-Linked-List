from flask import Flask
from flask import request

app = Flask(__name__)
 
@app.route('/')
def hello_world():
    return 'Hello World'
 



@app.route('/gamedev', methods = ['GET', 'POST'])
def game_development():
    if request.method == 'POST':
        # print('data is', request.args)
        # print('data is', request.form)
        # print('data is', request.files)
        # print('data is', request.json)
        # print('data is', request.values)
        print(request.form["thing1"])
        print(request.form["thing2"])
        #print(request.form['ImmutableMultiDict'])
    return 'We Develop A Backend For A Game'


if __name__ == '__main__':
    app.run(debug = True, host = '0.0.0.0')