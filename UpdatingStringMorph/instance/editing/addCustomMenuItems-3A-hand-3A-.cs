addCustomMenuItems: menu hand: aHandMorph

	| prefix |
	super addCustomMenuItems: menu hand: aHandMorph.
	prefix _ self growable
		ifTrue:
			['stop']
		ifFalse:
			['start'].
	menu add: prefix, ' being growable' action: #toggleGrowability.
	menu add: 'decimal places...' action: #setPrecision.
	menu add: 'font size...' action: #setFontSize.
	menu add: 'font style...' action: #setFontStyle