addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addLine.
	aCustomMenu add: 'start' translated action: #startRunning.
	aCustomMenu add: 'stop' translated action: #stopRunning.
	aCustomMenu add: 'step' translated action: #singleStep.
	aCustomMenu add: 'start over' translated action: #startOver.
	aCustomMenu addLine.
	aCustomMenu add: 'full speed' translated action: #fullSpeed.
	aCustomMenu add: 'slow speed' translated action: #slowSpeed.
	aCustomMenu addLine.
	aCustomMenu add: 'set scale' translated action: #setScale.
	aCustomMenu add: 'make parameter slider' translated action: #makeParameterSlider.
