newForEncoding: aString 
	| class encoding |
	aString ifNil: [^ Latin1TextConverter new].
	encoding _ aString asLowercase.
	class _ self allSubclasses
				detect: [:each | each encodingNames includes: encoding]
				ifNone: [].
	class isNil
		ifTrue: [^ nil].
	^ class new