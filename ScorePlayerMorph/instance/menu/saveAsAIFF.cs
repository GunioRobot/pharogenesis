saveAsAIFF
	"Create a stereo AIFF audio file with the result of performing my score."

	| fileName |
	fileName := FillInTheBlank request: 'New file name?' translated.
	fileName isEmpty ifTrue: [^ self].
	(fileName asLowercase endsWith: '.aif') ifFalse: [
		fileName := fileName, '.aif'].

	scorePlayer storeAIFFOnFileNamed: fileName.
