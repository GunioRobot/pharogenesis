allMethodsInCategory: aCategorySymbol forInstance: anObject ofClass: aClass
	"Answer a list of all methods in the etoy interface which are in the given category, on behalf of anObject, or if it is nil, aClass"

	| likelyReply |
	likelyReply _ super allMethodsInCategory: aCategorySymbol forInstance: anObject ofClass: aClass.
	^ ((anObject isKindOf: Player) and:
		[aCategorySymbol == #vector])
			ifFalse:
				[likelyReply]
			ifTrue:
				[anObject costume class vectorAdditions collect:
					[:anAddition | (self methodInterfaceFrom: anAddition) selector]]