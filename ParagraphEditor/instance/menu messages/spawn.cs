spawn
	"Create and schedule a message browser for the code of the model's 
	selected message. Retain any edits that have not yet been accepted."
	| code |
	code _ paragraph text string.
	self cancel.
	model notNil ifTrue:[model spawn: code].
