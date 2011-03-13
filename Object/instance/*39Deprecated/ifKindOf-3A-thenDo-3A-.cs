ifKindOf: aClass thenDo: aBlock
	self deprecated: 'Deprecated. Just use #isKindOf:'.
	^ (self isKindOf: aClass) ifTrue: [aBlock value: self]