addDismissButtonTo: aRowMorph
	aRowMorph addMorphBack:
		((SimpleButtonMorph new label: 'X' font: ScriptingSystem fontForScriptorButtons)
			target: self;
			color:  Color lightRed;
			actionSelector: #dismiss;
			balloonTextSelector: #dismiss).
	^ aRowMorph
