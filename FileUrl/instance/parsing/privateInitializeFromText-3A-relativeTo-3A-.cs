privateInitializeFromText: aString relativeTo: aUrl
	| bare |

	bare _ aString.

	(bare beginsWith: (self schemeName, ':')) ifTrue: [
		bare _ bare copyFrom: (self schemeName size + 2) to: bare size ].

	(bare beginsWith: '/') ifTrue: [ ^self privateInitializeFromText: aString ].

	isAbsolute _ aUrl isAbsolute.

	path _ aUrl path copy.
	path removeLast.	"empty string that says its a directory"
	(bare findTokens: '/') do: [ :token |
		((token ~= '..') and: [token ~= '.']) ifTrue: [ 
			path addLast: token unescapePercents ].
		token = '..' ifTrue: [ 
			path isEmpty ifFalse: [ 
				path last = '..' ifFalse: [ path removeLast ] ] ].
		"token = '.' do nothing" ].

	(bare endsWith: '/') ifTrue: [ path add: '' ].