wrapPanel: anLedPanel label: aLabel
	"wrap an LED panel in an alignmentMorph with a label to its left"

	^self rowForButtons
		color: color lighter;
		addMorph: anLedPanel;
		addMorph: (StringMorph contents: aLabel)
