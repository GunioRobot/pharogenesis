traverseRowTranslateSlotOld: oldSlotName to: newSlotName
	"Traverse my submorphs, translating submorphs appropriately given the slot rename"

	submorphs do: [:tile |
		(tile isKindOf: AssignmentTileMorph) ifTrue: 
			[tile assignmentRoot = oldSlotName ifTrue: [tile setRoot: newSlotName]].
		(tile isMemberOf: TileMorph) ifTrue:
			[(tile operatorOrExpression = (Utilities getterSelectorFor: oldSlotName)) ifTrue:
				[tile setOperator: (Utilities getterSelectorFor: newSlotName)]].
		tile traverseRowTranslateSlotOld: oldSlotName to: newSlotName]