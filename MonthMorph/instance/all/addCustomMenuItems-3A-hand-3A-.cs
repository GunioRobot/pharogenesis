addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu 
		addLine;
		addUpdating: #startMondayOrSundayString action: #toggleStartMonday;
		add: 'jump to year...' translated action: #chooseYear.