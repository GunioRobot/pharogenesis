saveAsWAV
	"Create a stereo WAV audio file with the result of performing my score."

	| fileName |
	fileName _ FillInTheBlank request: 'New file name?' translated.
	fileName isEmpty ifTrue: [^ self].
	(fileName asLowercase endsWith: '.wav') ifFalse: [
		fileName _ fileName, '.wav'].

	scorePlayer storeWAVOnFileNamed: fileName.
