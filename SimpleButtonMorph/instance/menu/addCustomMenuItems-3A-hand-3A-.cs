addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	self addLabelItemsTo: aCustomMenu hand: aHandMorph.
	(target isKindOf: BookMorph)
		ifTrue:
			[aCustomMenu add: 'set page sound' action: #setPageSound:.
			aCustomMenu add: 'set page visual' action: #setPageVisual:]
		ifFalse:
			[aCustomMenu add: 'change action selector' action: #setActionSelector.
			aCustomMenu add: 'change arguments' action: #setArguments.
			aCustomMenu add: 'change when to act' action: #setActWhen.
			((self world rootMorphsAt: aHandMorph targetOffset) size > 1) ifTrue:
				[aCustomMenu add: 'set target' action: #setTarget:]].
