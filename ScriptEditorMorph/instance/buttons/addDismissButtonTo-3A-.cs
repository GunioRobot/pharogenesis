addDismissButtonTo: aRowMorph
	aRowMorph addMorphBack:
		((SimpleButtonMorph new label: 'X' font: Preferences standardButtonFont)
			target: self;
			color:  Color lightRed;
			actionSelector: #dismiss;
			setBalloonText: 
'Remove this script
from the screen
(you can open it
again from a Viewer)').
	^ aRowMorph