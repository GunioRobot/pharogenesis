readDataFromFile

	| fileName |
	fileName _ FillInTheBlank
		request: 'File name?' translated
		initialAnswer: ''.
	fileName isEmpty ifTrue: [^ self].
	(StandardFileStream isAFileNamed: fileName) ifFalse: [
		^ self inform: 'Sorry, I cannot find that file' translated].
	self data: (SampledSound fromAIFFfileNamed: fileName) samples.

