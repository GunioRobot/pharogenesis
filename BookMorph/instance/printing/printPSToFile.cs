printPSToFile
	"Ask the user for a filename and print this morph as postscript."

	| fileName rotateFlag |
	fileName _ ('MyBook') asFileName.
	fileName _ FillInTheBlank request: 'File name? (".ps" will be added to end)' 
			initialAnswer: fileName.
	fileName size == 0 ifTrue: [^ self beep].
	(fileName endsWith: '.ps') ifFalse: [fileName _ fileName,'.ps'].

	rotateFlag _ ((PopUpMenu labels:
'portrait (tall)
landscape (wide)')
			startUpWithCaption: 'Choose orientation...') = 2.

	(FileStream newFileNamed: fileName)
		nextPutAll: (DSCPostscriptCanvas morphAsPostscript: self rotated: rotateFlag); close.

