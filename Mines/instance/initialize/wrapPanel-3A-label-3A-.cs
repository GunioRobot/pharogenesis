wrapPanel: anLedPanel label: aLabel
	"wrap an LED panel in an alignmentMorph with a label to its left"

	| a |
	a _ AlignmentMorph newRow
		wrapCentering: #center; cellPositioning: #leftCenter;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		borderWidth: 0;
		layoutInset: 3;
		color: color lighter.
	a addMorph: anLedPanel.
	a addMorph: (StringMorph contents: aLabel). 
	^ a
