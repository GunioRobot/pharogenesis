absoluteFromText: text
	"(how does this method fit with FileUrl|privateInitializeFromText:?)"

	| schemeName pathString bare thePath |
	bare _ text withBlanksTrimmed.
	schemeName _ Url schemeNameForString: bare.
	pathString _ schemeName
		ifNil: [bare]
		ifNotNil: [bare copyFrom: (schemeName size + 2) to: bare size].
	thePath _ (pathString findTokens: '/') collect: [:token | token unescapePercents].
	(pathString endsWith: '/') ifTrue: [thePath add: ''].

	"Hey, this only works on Unix!"
	^ self new path: thePath isAbsolute: (pathString beginsWith: '/')