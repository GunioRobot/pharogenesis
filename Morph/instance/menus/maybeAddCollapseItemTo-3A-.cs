maybeAddCollapseItemTo: aMenu
	"If appropriate, add a collapse item to the given menu"

	| anOwner |
	(anOwner _ self topRendererOrSelf owner) ifNotNil:
			[anOwner isWorldMorph ifTrue:
				[aMenu add: 'collapse' translated target: self action: #collapse]]