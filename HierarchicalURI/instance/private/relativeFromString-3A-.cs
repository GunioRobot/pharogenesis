relativeFromString: aString
	| remainder authorityEnd |
	remainder _ (aString beginsWith: '//')
		ifTrue: [
			authorityEnd _ aString indexOf: $/ startingAt: 3.
			authorityEnd == 0
				ifTrue: [authorityEnd _ aString size+1].
			self extractAuthority: (aString copyFrom: 3 to: authorityEnd-1)]
		ifFalse: [aString].
	self extractSchemeSpecificPartAndFragment: remainder