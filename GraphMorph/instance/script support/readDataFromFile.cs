readDataFromFile

	| fileName |
	fileName _ FillInTheBlank
		request: 'File name?'
		initialAnswer: ''.
	fileName isEmpty ifTrue: [^ self].
	(StandardFileStream isAFileNamed: fileName) ifFalse: [
		^ self inform: 'Sorry, I cannot find that file'].
	data _ (SampledSound readTrimmedSamplesFromAIFF: fileName).
	self flushCachedForm.
