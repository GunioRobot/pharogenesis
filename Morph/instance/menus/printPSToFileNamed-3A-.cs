printPSToFileNamed: aString 
	"Ask the user for a filename and print this morph as postscript."
	| fileName rotateFlag psCanvasType psExtension |
	fileName := aString asFileName.
	psCanvasType _ PostscriptCanvas defaultCanvasType.
	psExtension _ psCanvasType defaultExtension.
	fileName := FillInTheBlank request: (String streamContents: [ :s |
		s nextPutAll: ('File name? ("{1}" will be added to end)' translated format: {psExtension})])
			initialAnswer: fileName.
	fileName isEmpty
		ifTrue: [^ Beeper beep].
	(fileName endsWith: psExtension)
		ifFalse: [fileName := fileName , psExtension].
	rotateFlag := ((PopUpMenu labels: 'portrait (tall)
landscape (wide)' translated)
				startUpWithCaption: 'Choose orientation...' translated)
				= 2.
	((FileStream newFileNamed: fileName asFileName) converter: TextConverter defaultSystemConverter)
		nextPutAll: (psCanvasType morphAsPostscript: self rotated: rotateFlag);
		 close