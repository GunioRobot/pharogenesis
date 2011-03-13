privateInitializeFromText: aString relativeTo: aUrl 
	| remainder ind nextTok s |
	remainder _ aString.
	"set the scheme"
	schemeName _ aUrl schemeName.
	"a leading // means the authority is specified, meaning it is absolute"
	(remainder beginsWith: '//')
		ifTrue: [^ self privateInitializeFromText: aString].
	"otherwise, use the same authority"
	authority _ aUrl authority.
	port _ aUrl port.
	"get the query"
	ind _ remainder indexOf: $?.
	ind > 0
		ifTrue: [query _ remainder copyFrom: ind + 1 to: remainder size.
			remainder _ remainder copyFrom: 1 to: ind - 1].
	"get the path"
	remainder isEmpty
		ifTrue: [path _ aUrl path]
		ifFalse: [(remainder beginsWith: '/')
				ifTrue: [path _ OrderedCollection new]
				ifFalse: [path _ aUrl path shallowCopy.
					path size > 0
						ifTrue: [path removeLast]].
			s _ ReadStream on: remainder.
			[s peek = $/
				ifTrue: [s next].
			nextTok _ WriteStream on: String new.
			[s atEnd
				or: [s peek = $/]]
				whileFalse: [nextTok nextPut: s next].
			nextTok _ nextTok contents unescapePercents.
			nextTok = '..'
				ifTrue: [path size > 0
						ifTrue: [path removeLast]]
				ifFalse: [nextTok ~= '.'
						ifTrue: [path add: nextTok]].
			s atEnd] whileFalse.
			path isEmpty
				ifTrue: [path add: '']]