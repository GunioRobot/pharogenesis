ifKindOf: aClass thenDo: aBlock
	^ (self isKindOf: aClass) ifTrue: [aBlock value: self]