buildButton: aButton target: aTarget label: aLabel selector: aSelector
	"wrap a button or switch in an alignmentMorph to allow a row of buttons to fill space"

	| a |
	aButton 
		target: aTarget;
		label: aLabel;
		actionSelector: aSelector;
		borderColor: #raised;
		borderWidth: 2;
		color: color.
	a _ AlignmentMorph newColumn
		wrapCentering: #center; cellPositioning: #topCenter;
		hResizing: #spaceFill;
		vResizing: #shrinkWrap;
		color: color.
	a addMorph: aButton.
	^ a

