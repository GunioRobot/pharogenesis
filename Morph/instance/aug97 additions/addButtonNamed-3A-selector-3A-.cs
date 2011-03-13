addButtonNamed: label selector: aSymbol
	"Elevated from EToyPaletterMorph to here, so that any kind of object can add one."
	| b |
	b _ StringButtonMorph new.
	b	contents: label;
		color: self buttonOffColor;
		target: self;
		actionSelector: aSymbol;
		setNameTo: label.
	self addMorphBack: b.
