setNameTo: aName
	| nameToUse nameString |
	nameToUse _ aName ifNotNil:
		[(nameString _ aName asString) size > 0 ifTrue: [nameString] ifFalse: ['�']].
	self setNamePropertyTo: nameToUse "no Texts here!"