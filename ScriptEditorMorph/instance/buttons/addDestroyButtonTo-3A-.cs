addDestroyButtonTo: aRowMorph
	aRowMorph addMorphBack:
		((SimpleButtonMorph new label: 'X' font: Preferences standardButtonFont)
			target: self;
			color:  Color lightRed;
			actionSelector: #destroyScript;
			setBalloonText: 
'Destroy this script
(CAUTION!!)').
	^ aRowMorph