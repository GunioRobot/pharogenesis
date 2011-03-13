setNewFormFrom: formOrNil
	"Set the receiver's form as indicated.   If nil is provided, then a default form will be used, possibly retrieved from the receiver's defaultValue property"

	| defaultImage |
	formOrNil ifNotNil: [^ self form: formOrNil].
	defaultImage := ScriptingSystem squeakyMouseForm.
	self form: defaultImage
