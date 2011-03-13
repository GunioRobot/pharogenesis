properlyInitialize
	selfSenders isEmptyOrNil ifTrue: [selfSenders := IdentityDictionary new].
	superSenders isEmptyOrNil ifTrue: [superSenders := IdentityDictionary new].
	classSenders isEmptyOrNil ifTrue: [classSenders := IdentityDictionary new].
	
