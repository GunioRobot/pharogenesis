privateInitializeFromText: text

	| bare schemeName pathString |
	bare _ text withBlanksTrimmed.
	schemeName _ Url schemeNameForString: bare.
	schemeName
		ifNil: [ pathString _ bare ]
		ifNotNil: [ pathString _ bare copyFrom: (schemeName size + 2) to: bare size ].

	path _ pathString findTokens: '/'.
	path _ path collect: [:token | token unescapePercents].
	(pathString endsWith: '/') ifTrue: [ path addLast: '' ].

	isAbsolute _ pathString beginsWith: '/'.