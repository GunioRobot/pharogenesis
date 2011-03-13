addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
"template..."
	aCustomMenu addLine.
	aCustomMenu add: 'rename me' action: #renameMe.
	aCustomMenu addLine.
	aCustomMenu add: 'plug mouseDown to model slot' action: #plugMouseDownToSlot.
	aCustomMenu add: 'plug mouseMove to model slot' action: #plugMouseMoveToSlot.
	aCustomMenu add: 'plug all to model slots' action: #plugAllToSlots.
	aCustomMenu addLine.
	aCustomMenu add: 'plug mouseDown to model' action: #plugMouseDownToModel.
	aCustomMenu add: 'plug mouseMove to model' action: #plugMouseMoveToModel.
	aCustomMenu add: 'plug all to model' action: #plugAllToModel.
	aCustomMenu addLine.
	aCustomMenu add: 'set target...' action: #setTarget.
	aCustomMenu add: 'set mouseDown selector...' action: #setMouseDownSelector.
	aCustomMenu add: 'set mouseMove selector...' action: #setMouseMoveSelector.
	aCustomMenu add: 'set mouseUp selector...' action: #setMouseUpSelector.
