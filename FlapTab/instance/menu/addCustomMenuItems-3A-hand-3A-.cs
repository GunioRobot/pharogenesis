addCustomMenuItems: aMenu hand: aHandMorph

	aMenu addLine.
	aMenu addUpdating: #textualTabString action: #textualTab.
	aMenu addUpdating: #graphicalTabString action: #graphicalTab.
	aMenu addUpdating: #solidTabString enablement: #notSolid action: #solidTab.
	aMenu addLine.

	(referent isKindOf: PasteUpMorph) ifTrue: 
		[aMenu addUpdating: #partsBinString action: #togglePartsBinMode].
	aMenu addUpdating: #dragoverString action: #toggleDragOverBehavior.
	aMenu addUpdating: #mouseoverString action: #toggleMouseOverBehavior.
	"aMenu addUpdating: #slideString action: #toggleSlideBehavior.
	aMenu addUpdating: #inboardString action: #toggleInboardness."
	"aMenu addUpdating: #thicknessString ('thickness... (current: ', self thickness printString, ')') action: #setThickness."
	aMenu addUpdating: #edgeString action: #setEdgeToAdhereTo.
	aMenu addLine.
	aMenu add: 'destroy this flap' action: #destroyFlap.