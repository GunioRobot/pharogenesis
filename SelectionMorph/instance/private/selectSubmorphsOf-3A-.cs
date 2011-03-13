selectSubmorphsOf: aMorph

	| newItems removals |
	newItems _ aMorph submorphs select:
		[:m | (bounds containsRect: m fullBounds) 
					and: [m~~self
					and: [(m isKindOf: HaloMorph) not]]].
	otherSelection ifNil: [^ selectedItems _ newItems].

	removals _ newItems intersection: itemsAlreadySelected.
	otherSelection setSelectedItems: (itemsAlreadySelected copyWithoutAll: removals).
	selectedItems _ (newItems copyWithoutAll: removals).
