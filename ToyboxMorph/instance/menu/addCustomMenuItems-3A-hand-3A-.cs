addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addLine.
	aCustomMenu
		add: (locked ifTrue: ['unlock me'] ifFalse: ['lock me'])
		action: #toggleLocked.
	aCustomMenu
		add: (copyWhenLocked
				ifTrue: ['don''t drag out copies when locked']
				ifFalse: ['drag out copies when locked'])
		action: #toggleCopyWhenLocked.
