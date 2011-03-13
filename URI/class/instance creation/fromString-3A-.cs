fromString: aString
	| parseString scheme |
	parseString _ aString withBlanksTrimmed.
	scheme _ self extractSchemeFrom: parseString.
	^scheme
		ifNil: [HierarchicalURI new relativeFromString: aString]
		ifNotNil: [self absoluteFromString: aString scheme: scheme]
