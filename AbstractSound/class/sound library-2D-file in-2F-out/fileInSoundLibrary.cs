fileInSoundLibrary
	"Prompt the user for a file name and the file in the sound library with that name."
	"AbstractSound fileInSoundLibrary"

	| fileName |
	fileName _ FillInTheBlank request: 'Sound library file name?'.
	fileName isEmptyOrNil ifTrue: [^ self].
	(fileName endsWith: '.sounds') ifFalse: [fileName _ fileName, '.sounds'].
	self fileInSoundLibraryNamed: fileName.
