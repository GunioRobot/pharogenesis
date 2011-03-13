readUrlFromFile: aFile
	| oldFile url |
	oldFile _ FileStream oldFileOrNoneNamed: aFile.
	oldFile isBinary 
		ifTrue:[ self error: 'not url file']
		ifFalse:[url _ (oldFile contentsOfEntireFile) withBlanksTrimmed.
				url =='' ifTrue:[ self error: 'blank file: url not exist'].
				^url asUrl].
	