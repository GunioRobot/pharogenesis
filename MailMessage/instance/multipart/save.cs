save
	"save the part to a file"
	| fileName file |
	fileName _ self name
				ifNil: ['attachment' , Utilities dateTimeSuffix].
	(fileName includes: $.) ifFalse: [
		#(isJpeg 'jpg' isGif 'gif' isPng 'png' isPnm 'pnm') pairsDo: [ :s :e |
			(self body perform: s) ifTrue: [fileName _ fileName, '.', e]
		]
	].
	fileName _ FillInTheBlank request: 'File name for save?' initialAnswer: fileName.
	fileName isEmpty
		ifTrue: [^ nil].
	file _ FileStream newFileNamed: fileName.
	file nextPutAll: self bodyText.
	file close