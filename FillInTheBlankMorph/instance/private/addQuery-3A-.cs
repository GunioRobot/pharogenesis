addQuery: queryString

	| lines queryMorph |
	lines _ queryString asString findTokens: String cr.
	queryMorph _ AlignmentMorph newColumn
		borderWidth: 0;
		inset: 4;
		centering: #center;
		color: self color;
		width: self innerBounds width;
		hResizing: #spaceFill;
		vResizing: #shrinkWrap;
		position: self innerBounds topLeft.
	lines do: [:s | queryMorph addMorphBack: (StringMorph contents: s)].
	self addMorph: queryMorph.
