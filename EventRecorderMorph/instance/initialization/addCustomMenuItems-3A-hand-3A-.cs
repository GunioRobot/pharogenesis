addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'add voice controls' action: #addVoiceControls.
	aCustomMenu add: 'add journal file' action: #addJournalFile.
