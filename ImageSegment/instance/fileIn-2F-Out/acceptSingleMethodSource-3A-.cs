acceptSingleMethodSource: aDictionary

	| oldClassInfo oldClassName ismeta newName actualClass selector |
	oldClassInfo _ (aDictionary at: #oldClassName) findTokens: ' '.	"'Class' or 'Class class'"
	oldClassName _ oldClassInfo first asSymbol.
	ismeta _ oldClassInfo size > 1.

	"must use class var since we may not be the same guy who did the initial work"

	newName _ RecentlyRenamedClasses ifNil: [
		oldClassName
	] ifNotNil: [
		RecentlyRenamedClasses at: oldClassName ifAbsent: [oldClassName]
	].
	actualClass _ Smalltalk at: newName.
	ismeta ifTrue: [actualClass _ actualClass class].
	selector _ actualClass parserClass new parseSelector: (aDictionary at: #methodText).
	(actualClass compiledMethodAt: selector ifAbsent: [^self "hosed input"]) 
		putSource: (aDictionary at: #methodText)
		fromParseNode: nil
		class: actualClass
		category: (aDictionary at: #category)
		withStamp: (aDictionary at: #changeStamp)
		inFile: 2
		priorMethod: nil.

