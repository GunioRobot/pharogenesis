text
	^ source 
		ifNotNil: [source asText makeSelectorBold]
		ifNil: [self theClass sourceCodeTemplate]