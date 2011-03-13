absoluteFromString: aString scheme: scheme
	| remainder |
	remainder := aString copyFrom: scheme size+2 to: aString size.
	remainder isEmpty
		ifTrue: [(IllegalURIException new uriString: aString) signal: 'Invalid absolute URI'].
	^(remainder first = $/
		ifTrue: [(aString last = $/
					ifTrue: [DirectoryURI]
					ifFalse: [HierarchicalURI])]
		ifFalse: [OpaqueURI]) new absoluteFromString: remainder scheme: scheme