addCustomMenuItems: aCustomMenu hand: aHand
	super addCustomMenuItems: aCustomMenu hand: aHand.
	aCustomMenu addLine.
	aCustomMenu addUpdating: #getHQTextureState action: #toggleHQTextureState.
	aCustomMenu addUpdating: #getActiveTextureState action: #toggleActiveTextureState.
	aCustomMenu addUpdating: #getTextureAdjust action: #toggleTextureAdjust.
	aCustomMenu add:'set user point of view' action:#setUserPointOfView.