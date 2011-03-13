addMorph: aMorph frame: relFrame
	| panelRect |
	self addMorph: aMorph.
	paneMorphs _ paneMorphs copyReplaceFrom: 1 to: 0 with: (Array with: aMorph).
	paneRects _ paneRects copyReplaceFrom: 1 to: 0 with: (Array with: relFrame).

	panelRect _ self panelRect.
	aMorph borderWidth: 1;
		color: (Color perform: model defaultBackgroundColor);
		bounds: ((relFrame scaleBy: panelRect extent) translateBy: panelRect topLeft) truncated.
