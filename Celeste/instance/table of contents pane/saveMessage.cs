saveMessage
	"save the currently selected message to a file"
	| fileName file |
	currentMsgID ifNil: [^ self].
	fileName _ FillInTheBlank request: 'file to save in'.
	fileName isEmpty ifTrue: [^ self].
	file _ FileStream fileNamed: fileName.
	file nextPutAll: (self currentMessage) text.
	file close