traverseRowTranslateSlotOld: oldSlotName of: aPlayer to: newSlotName
	"Traverse my submorphs, translating submorphs appropriately given the slot rename"

	submorphs do: [:tile |
		(tile isKindOf: AssignmentTileMorph) ifTrue:
			[tile assignmentRoot = oldSlotName ifTrue:
				[(self isPlayer: aPlayer ofReferencingTile: tile) ifTrue:
					[tile setRoot: newSlotName]]].
		(tile isMemberOf: TileMorph) ifTrue:
			[(tile operatorOrExpression = (Utilities getterSelectorFor: oldSlotName)) ifTrue:
				[(self isPlayer: aPlayer ofReferencingTile: tile) ifTrue:
					[tile setOperator: (Utilities getterSelectorFor: newSlotName)]]].
		tile traverseRowTranslateSlotOld: oldSlotName of: aPlayer to: newSlotName]