setNameTo: aName
	| nameToUse nameString |
	nameToUse _ aName ifNotNil:
		[(nameString _ aName asString) size > 0 ifTrue: [nameString] ifFalse: ['É']].
	self setNamePropertyTo: nameToUse "no Texts here!"