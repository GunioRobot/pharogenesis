addCustomMenuItems: aMenu hand: aHandMorph

	aMenu addLine.
	aMenu addUpdating: #dragoverString action: #toggleDragOverBehavior.
	aMenu addUpdating: #mouseoverString action: #toggleMouseOverBehavior.
	aMenu addUpdating: #edgeString action: #setEdgeToAdhereTo.
	aMenu addLine.
	aMenu add: 'destroy this flap' action: #destroyFlap.