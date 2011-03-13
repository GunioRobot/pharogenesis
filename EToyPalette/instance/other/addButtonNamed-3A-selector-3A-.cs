addButtonNamed: label selector: aSymbol

	| b |
	b _ StringButtonMorph new.
	b	contents: label;
		color: self buttonOffColor;
		target: self;
		actionSelector: aSymbol.
	self addMorphBack: b.
