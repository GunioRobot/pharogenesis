printPSToFile
	"Ask the user for a filename and print this morph as postscript."

	| fileName rotateFlag |
	fileName _ ('MyBook') translated asFileName.
	fileName _ FillInTheBlank request: 'File name? (".ps" will be added to end)' translated 
			initialAnswer: fileName.
	fileName isEmpty ifTrue: [^ Beeper beep].
	(fileName endsWith: '.ps') ifFalse: [fileName _ fileName,'.ps'].

	rotateFlag _ ((PopUpMenu labels:
'portrait (tall)
landscape (wide)' translated) 
			startUpWithCaption: 'Choose orientation...' translated) = 2.

	(FileStream newFileNamed: fileName asFileName)
		nextPutAll: (DSCPostscriptCanvas morphAsPostscript: self rotated: rotateFlag); close.

