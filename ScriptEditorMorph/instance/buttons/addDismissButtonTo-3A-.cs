addDismissButtonTo: aRowMorph
	aRowMorph addMorphBack:
		((SimpleButtonMorph new label: 'O' font: Preferences standardButtonFont)
			target: self;
			color:  Color tan;
			actionSelector: #dismiss;
			setBalloonText: 
'Remove this script
from the screen
(you can open it
again from a Viewer)').
	^ aRowMorph