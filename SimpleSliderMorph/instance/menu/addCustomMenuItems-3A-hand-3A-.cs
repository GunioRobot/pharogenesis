addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addLine.
	aCustomMenu add: 'set action selector' action: #setActionSelector.
	aCustomMenu add: 'change arguments' action: #setArguments.
	aCustomMenu add: 'set minimum value' action: #setMinVal.
	aCustomMenu add: 'set maximum value' action: #setMaxVal.
	truncate
		ifTrue: [aCustomMenu add: 'turn off truncating' action: #toggleTruncate]
		ifFalse: [aCustomMenu add: 'turn on truncating' action: #toggleTruncate].
	((self world rootMorphsAt: aHandMorph targetOffset) size > 1) ifTrue: [
		aCustomMenu add: 'set target' action: #setTarget:].
	target ifNotNil: [
		aCustomMenu add: 'clear target' action: #clearTarget].
