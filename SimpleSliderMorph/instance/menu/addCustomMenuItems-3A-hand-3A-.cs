addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addLine.
	aCustomMenu add: 'set action selector' translated action: #setActionSelector.
	aCustomMenu add: 'change arguments' translated action: #setArguments.
	aCustomMenu add: 'set minimum value' translated action: #setMinVal.
	aCustomMenu add: 'set maximum value' translated action: #setMaxVal.
	aCustomMenu addUpdating: #descendingString action: #toggleDescending.
	aCustomMenu addUpdating: #truncateString action: #toggleTruncate.
	((self world rootMorphsAt: aHandMorph targetOffset) size > 1) ifTrue: [
		aCustomMenu add: 'set target' translated action: #setTarget:].
	target ifNotNil: [
		aCustomMenu add: 'clear target' translated action: #clearTarget].
