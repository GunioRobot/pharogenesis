addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu
		addLine;
		add: 'magnification...' action: #chooseMagnification;
		addUpdating: #trackingPointerString action: #toggleTrackingPointer;
		addUpdating: #toggleRoundString action: #toggleRoundness.