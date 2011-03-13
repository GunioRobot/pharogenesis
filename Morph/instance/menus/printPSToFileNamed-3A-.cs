printPSToFileNamed: aString
	"Ask the user for a filename and print this morph as postscript."

	| fileName rotateFlag |
	fileName _ aString asFileName.
	fileName _ FillInTheBlank 
		request: 'File name? (".eps" will be added to end)' 
		initialAnswer: fileName.
	fileName size == 0 ifTrue: [^ self beep].
	(fileName endsWith: '.eps') ifFalse: [fileName _ fileName,'.eps'].

	rotateFlag _ ((PopUpMenu labels:
'portrait (tall)
landscape (wide)')
			startUpWithCaption: 'Choose orientation...') = 2.

	(FileStream newFileNamed: fileName)
		nextPutAll: (
			PostscriptCanvas defaultCanvasType morphAsPostscript: self rotated: rotateFlag
		); close.

