deleteBalloon
	"If I am showing one, remove it."
	| balloon |
	(balloon _ self valueOfProperty: #balloon) ifNil: [^ self].  "No balloon to delete"
	balloon owner ifNil: [^ self].  "Already deleted"
	balloon delete.
	self setProperty: #balloon toValue: nil.
	self world ifNotNil: [self world displayWorld]  "It happens  that it can be nil-- such as on at 9/20/97 15:20"