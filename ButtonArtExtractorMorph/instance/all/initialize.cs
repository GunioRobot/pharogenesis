initialize

	super initialize.
	borderWidth _ 2.
	inset _ 3.
	orientation _ #vertical.
	self addButtonRows.
	layers _ EmptyArray.
	visibleLayer _ SketchMorph new form: (Form extent: 50@40).
	selectionRect _ RectangleMorph new
		color: Color transparent;
		borderColor: Color magenta;
		borderWidth: 3.
	visibleLayer addMorph: selectionRect.
	previewer _ ImageMorph new.
	self addMorphBack: (Morph new color: color; extent: 1@4).  "spacer"
	self addMorphBack: visibleLayer.
	self addMorphBack: (Morph new color: color; extent: 1@4).  "spacer"
	self addMorphBack: previewer.
	self updatePreview.
