saveAsAIFF
	"Create a stereo AIFF audio file with the result of performing my score."

	| fileName |
	fileName _ FillInTheBlank request: 'New file name?' translated.
	fileName isEmpty ifTrue: [^ self].
	(fileName asLowercase endsWith: '.aif') ifFalse: [
		fileName _ fileName, '.aif'].

	scorePlayer storeAIFFOnFileNamed: fileName.
