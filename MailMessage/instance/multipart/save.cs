save
	"save the part to a file"
	| fileName file |
	fileName _ self name ifNil: ['attachment' , Utilities dateTimeSuffix].
	fileName _ FillInTheBlank request: 'File name for save?' initialAnswer: fileName.

	fileName isEmpty ifTrue: [ ^nil ].

	file _ FileStream newFileNamed: fileName.
	file nextPutAll: self content.
	file close.