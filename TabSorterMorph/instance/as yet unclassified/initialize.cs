initialize
	super initialize.
	self removeAllMorphs.

	self extent: 300@100.
	pageHolder _ PasteUpMorph new.
	pageHolder resizeToFit: true; autoLineLayout: true; fixLayout; layoutChanged.
	pageHolder extent: self extent - borderWidth.
	pageHolder padding: 8.
	pageHolder cursor: 0.
	self addControls.
	self addMorphBack: pageHolder