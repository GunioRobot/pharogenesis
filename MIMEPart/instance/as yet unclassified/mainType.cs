mainType
	| type |
	type _ self fields at: 'content-type' ifAbsent: [^'application'].
	^ (type mainValue findTokens: '/') first