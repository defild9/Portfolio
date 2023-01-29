from flask import Flask, render_template, redirect, url_for
from flask_wtf import FlaskForm
from wtforms import StringField, PasswordField, EmailField, SubmitField, TextAreaField
from wtforms.validators import InputRequired, Email, Length
from flask_sqlalchemy import SQLAlchemy
from werkzeug.security import generate_password_hash, check_password_hash
from flask_login import LoginManager, UserMixin, login_user, login_required, logout_user, current_user

app = Flask(__name__)
app.config['SECRET_KEY'] = 'abobaasdasdasdasfdsdgfdsjsjgbjfkfjlhl'
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///database.db'
db = SQLAlchemy(app)
app.app_context().push()

# for user login
login_manager = LoginManager()
login_manager.init_app(app)
login_manager.login_view = 'login'

@login_manager.user_loader
def load_user(user_id):
    return User.query.get(int(user_id))

#DataBase
class User(UserMixin, db.Model):
    id = db.Column(db.Integer, primary_key=True)
    username = db.Column(db.String(80), unique=True, nullable=False)
    email = db.Column(db.String(120), unique=True, nullable=False)
    password = db.Column(db.String(120), nullable=False)

class Albums(UserMixin, db.Model):
    id = db.Column(db.Integer, primary_key=True)
    name = db.Column(db.String(80), unique=True, nullable=False)
    year = db.Column(db.String(120),  nullable=False)
    description = db.Column(db.String(120), nullable=False)

# Forms
class LoginForm(FlaskForm):
    username = StringField('username', validators=[InputRequired(), Length(min=4, max=20),],render_kw={"placeholder":"Username"})
    password = PasswordField('password', validators=[InputRequired(), Length(min=6, max=64)],render_kw={"placeholder":"Password"})
    submit = SubmitField('Login')

class RegisterForm(FlaskForm):
    email = EmailField('email', validators=[InputRequired(), Email(message='Invalid email')], render_kw={"placeholder":"Email"})
    username = StringField('username', validators=[InputRequired(), Length(min=4, max=20)], render_kw={"placeholder":"Username"})
    password = PasswordField('password', validators=[InputRequired(), Length(min=6, max=64)], render_kw={"placeholder":"Password"})
    submit = SubmitField('Register')
# Add albums
class AddAlbumForm(FlaskForm):
    name = StringField('name', validators=[InputRequired(), Length(min=1, max=60)], render_kw={"placeholder":"Title"})
    year = StringField('year', validators=[InputRequired(), Length(min=1, max=4)], render_kw={"placeholder":"Year"})
    description = TextAreaField('description', validators=[InputRequired()], render_kw={"placeholder":"Discription"})
    submit = SubmitField('Register')

@app.context_processor
def check_user_login():
    return dict(user_status = current_user.is_authenticated)

# Routes
@app.route('/')
def index():
    return render_template('index.html')

@app.route('/login', methods=['GET','POST'])
def login():
    form = LoginForm()
    if current_user.is_authenticated:
        return redirect(url_for('dashboard'))
    else:
        if form.validate_on_submit():
            user = User.query.filter_by(username=form.username.data).first()
            if user:
                if check_password_hash(user.password, form.password.data):
                    login_user(user)
                    return redirect(url_for('dashboard'))
            # Can change to html page
            return f"<h1>Invalid user name or password</h1>"


    return render_template('login.html', form=form)

@app.route('/register', methods=['GET','POST'])
def register():
    form = RegisterForm()

    if current_user.is_authenticated:
        return redirect(url_for('dashboard'))
    else:
        if form.validate_on_submit():
            hash_password = generate_password_hash(form.password.data, method='sha256')
            new_user = User(username=form.username.data, email=form.email.data, password=hash_password)
            try:
                db.session.add(new_user)
                db.session.commit()
                return redirect(url_for('login'))
            except:
                return "Error!!!"

    return render_template('register.html', form=form)

@app.route('/dashboard')
@login_required
def dashboard():
    return render_template('dashboard.html', name=current_user.username)

@app.route('/dashboard/edit')
@login_required
def edit():
    albums = Albums.query.all()
    return render_template('edit.html', albums=albums)

@app.route('/dashboard/edit/albums/<int:id>/delete')
@login_required
def delete(id):
    album = Albums.query.get_or_404(id)
    db.session.delete(album)
    db.session.commit()
    return redirect(url_for('edit'))

@app.route('/add', methods=['GET','POST'])
@login_required
def add():
    form = AddAlbumForm()

    if form.validate_on_submit():
        new_album = Albums(name=form.name.data, year=form.year.data, description=form.description.data)
        try:
            db.session.add(new_album)
            db.session.commit()
            return redirect(url_for('albums'))
        except:
            return "Error!!"

    return render_template('add.html', form=form)

@app.route('/logout')
def logout():
    logout_user()
    return redirect(url_for('index'))

@app.route('/albums')
def albums():
    albums = Albums.query.all()
    return render_template('albums.html', albums=albums)

@app.route('/albums/<int:id>')
def albums_more(id):
    album = Albums.query.get(id)
    return render_template('album_detail.html', album=album)

@app.route('/about')
def about():
    return render_template('about.html')


if __name__ == '__main__':
    app.run(debug=True)
