bringAllSiblingsToMe: evt
	"bring all siblings of the receiver's player found in the same container to the receiver's location."

	| aPlayer aPosition aContainer |
	(aPlayer _ self topRendererOrSelf player) belongsToUniClass ifFalse: [self error: 'not uniclass'].
	aPosition _ self topRendererOrSelf position.
	aContainer _ self topRendererOrSelf owner.
	(aPlayer class allInstances copyWithout: aPlayer) do:
		[:each |
			(aContainer submorphs includes: each costume) ifTrue:
				[each costume  position: aPosition]]