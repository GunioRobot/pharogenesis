buildButton: aButton target: aTarget label: aLabel selector: aSelector
	"wrap a button or switch in an alignmentMorph to provide some space around the button"

	| a |
	aButton 
		target: aTarget;
		label: aLabel;
		actionSelector: aSelector;
		borderColor: #raised;
		borderWidth: 2;
		color: Color gray.
	a _ AlignmentMorph newColumn
		centering: #center;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		color: Color transparent;
		inset: 1.
	a addMorph: aButton.
	^ a

