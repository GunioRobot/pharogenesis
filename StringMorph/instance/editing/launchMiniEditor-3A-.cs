launchMiniEditor: evt

	| textMorph |
	hasFocus _ true.  "Really only means edit in progress for this morph"
	textMorph _ StringMorphEditor new contentsAsIs: contents.
	textMorph beAllFont: self fontToUse.
	textMorph bounds: (self bounds expandBy: 0@2).
	self addMorphFront: textMorph.
	evt hand newMouseFocus: textMorph.
	evt hand newKeyboardFocus: textMorph.
	textMorph editor selectFrom: 1 to: textMorph paragraph text string size