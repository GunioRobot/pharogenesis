addCustomMenuItems: aCustomMenu hand: aHandMorph 
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addLine.
	aCustomMenu addUpdating: #firstPersonControlString action: #toggleFirstPersonControl.
	aCustomMenu addUpdating: #showControlsString action: #toggleCameraControls.
	aCustomMenu addUpdating: #getAcceleratorState action: #toggleAcceleratorState.
	aCustomMenu addLine.
	aCustomMenu addUpdating: #getAAPaintState action: #toggleAAPaintState.
	aCustomMenu addLine.
	aCustomMenu add: 'Stop/Go button' action: #attachStopGoButtons.
	aCustomMenu add: 'Load actor' action: #loadActor.
