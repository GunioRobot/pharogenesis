buildButtonTarget: aTarget label: aLabel selector: aSelector help: aString

	^self rowForButtons
		addMorph: (
			SimpleButtonMorph new 
				target: aTarget;
				label: aLabel;
				actionSelector: aSelector;
				borderColor: #raised;
				borderWidth: 2;
				color: color
		)

