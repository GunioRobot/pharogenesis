newHSVASelectorIn: aThemedMorph color: aColor help: helpText
	"Answer a hue-saturation-volume-alpha selector."

	^HSVAColorSelectorMorph new
		selectedColor: aColor;
		hResizing: #spaceFill;
		vResizing: #spaceFIll;
		setBalloonText: helpText