wrapPanel: anLedPanel label: aLabel
	"wrap an LED panel in an alignmentMorph with a label to its left"

	| a |
	a _ AlignmentMorph newRow
		centering: #center;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		borderWidth: 0;
		inset: 3;
		color: color lighter.
	a addMorph: anLedPanel.
	a addMorph: (StringMorph contents: aLabel). 
	^ a

