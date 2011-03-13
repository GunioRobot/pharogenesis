replace: oldSelector with: newSelector in: aText
	| oldKeywords newKeywords args newSelectorWithArgs startOfSource lastSelectorToken |
	oldKeywords _ oldSelector keywords.
	newKeywords _ (newSelector ifNil: [self defaultSelector]) keywords.
	self assert: oldKeywords size = newKeywords size.
	args _ (self methodClass parserClass new
		parseArgsAndTemps: aText string notifying: nil) copyFrom: 1 to: self numArgs.
	newSelectorWithArgs _ String streamContents: [:stream |
		newKeywords withIndexDo: [:keyword :index |
			stream nextPutAll: keyword.
			stream space.
			args size >= index ifTrue: [
				stream nextPutAll: (args at: index); space]]].
	lastSelectorToken _ args isEmpty
		ifFalse: [args last]
		ifTrue: [oldKeywords last].
	startOfSource _ (aText string
		indexOfSubCollection: lastSelectorToken startingAt: 1) + lastSelectorToken size.
	^newSelectorWithArgs withBlanksTrimmed asText , (aText copyFrom: startOfSource to: aText size)