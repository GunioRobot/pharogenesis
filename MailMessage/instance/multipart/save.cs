save
	"save the part to a file"
	| fileName file |
	fileName _ self name
				ifNil: ['attachment' , Utilities dateTimeSuffix].
	(fileName includes: $.) ifFalse: [
		self body isJpeg
			ifTrue: [fileName _ fileName , '.jpg'].
		self body isGif ifTrue: [fileName _ fileName, '.gif']. ].
	fileName _ FillInTheBlank request: 'File name for save?' initialAnswer: fileName.
	fileName isEmpty
		ifTrue: [^ nil].
	file _ FileStream newFileNamed: fileName.
	file binary.
	file nextPutAll: self bodyText.
	file close