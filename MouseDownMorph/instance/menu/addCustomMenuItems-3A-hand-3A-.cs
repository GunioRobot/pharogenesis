addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
"template..."
	aCustomMenu addLine.
	aCustomMenu add: 'set variable name...' translated action: #renameMe.
	aCustomMenu addLine.
	aCustomMenu add: 'plug mouseDown to model slot' translated action: #plugMouseDownToSlot.
	aCustomMenu add: 'plug mouseMove to model slot' translated action: #plugMouseMoveToSlot.
	aCustomMenu add: 'plug all to model slots' translated action: #plugAllToSlots.
	aCustomMenu addLine.
	aCustomMenu add: 'plug mouseDown to model' translated action: #plugMouseDownToModel.
	aCustomMenu add: 'plug mouseMove to model' translated action: #plugMouseMoveToModel.
	aCustomMenu add: 'plug all to model' translated action: #plugAllToModel.
	aCustomMenu addLine.
	aCustomMenu add: 'set target...' translated action: #setTarget.
	aCustomMenu add: 'set mouseDown selector...' translated action: #setMouseDownSelector.
	aCustomMenu add: 'set mouseMove selector...' translated action: #setMouseMoveSelector.
	aCustomMenu add: 'set mouseUp selector...' translated action: #setMouseUpSelector.
