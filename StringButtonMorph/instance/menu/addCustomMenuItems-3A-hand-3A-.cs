addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'change label' action: #setLabel.
	aCustomMenu add: 'change action selector' action: #setActionSelector.
	aCustomMenu add: 'change arguments' action: #setArguments.
	aCustomMenu add: 'change when to act' action: #setActWhen.
	((self world rootMorphsAt: aHandMorph targetOffset) size > 1) ifTrue: [
		aCustomMenu add: 'set target' action: #setTarget:].
