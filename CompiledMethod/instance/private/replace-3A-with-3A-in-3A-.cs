replace: oldSelector with: newSelector in: aText
	| oldKeywords newKeywords args newSelectorWithArgs startOfSource lastSelectorToken |
	oldKeywords := oldSelector keywords.
	newKeywords := (newSelector ifNil: [self defaultSelector]) keywords.
	self assert: oldKeywords size = newKeywords size.
	args := (self methodClass parserClass new
		parseArgsAndTemps: aText string notifying: nil) copyFrom: 1 to: self numArgs.
	newSelectorWithArgs := String streamContents: [:stream |
		newKeywords withIndexDo: [:keyword :index |
			stream nextPutAll: keyword.
			stream space.
			args size >= index ifTrue: [
				stream nextPutAll: (args at: index); space]]].
	lastSelectorToken := args isEmpty
		ifFalse: [args last]
		ifTrue: [oldKeywords last].
	startOfSource := (aText string
		indexOfSubCollection: lastSelectorToken startingAt: 1) + lastSelectorToken size.
	^newSelectorWithArgs withBlanksTrimmed asText , (aText copyFrom: startOfSource to: aText size)