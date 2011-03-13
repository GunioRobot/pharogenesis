fromString: aString
	| parseString scheme |
	parseString := aString withBlanksTrimmed.
	scheme := self extractSchemeFrom: parseString.
	^scheme
		ifNil: [aString size > 1
				ifTrue: [(aString last = $/
					ifTrue: [DirectoryURI]
					ifFalse: [HierarchicalURI]) new relativeFromString: aString]
				ifFalse: [HierarchicalURI new relativeFromString: aString]]
		ifNotNil: [self absoluteFromString: aString scheme: scheme]
