addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'border color' action: #changeBorderColor:.
	aCustomMenu add: 'border width' action: #changeBorderWidth:.
	aCustomMenu add: 'change label' action: #setLabel.
	aCustomMenu add: 'script' action: #editScript:.
