addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'gradient color' action: #setGradientColor:.
	gradientDirection == #vertical
		ifTrue: [aCustomMenu add: 'horizontal pan' action: #beHorizontal]
		ifFalse: [aCustomMenu add: 'vertical pan' action: #beVertical].
