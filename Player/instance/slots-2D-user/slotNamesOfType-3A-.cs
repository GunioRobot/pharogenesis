slotNamesOfType: aType
	"Answer a list of potential slot names of the given type in the receiver"

	| fullList forViewer gettersToOffer |
	fullList _ (ScriptingSystem systemSlotNamesOfType: aType),
		(self class slotGettersOfType: aType).
	forViewer _ costume renderedMorph selectorsForViewer select:
		[:aSel | aSel beginsWith: 'get'].
	gettersToOffer _ fullList select: [:anItem | forViewer includes: anItem].
	^ gettersToOffer collect:
		[:aSel | Utilities inherentSelectorForGetter: aSel]