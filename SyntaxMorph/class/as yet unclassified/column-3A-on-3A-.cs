column: aColor on: aParseNode

	| c color |
	color _ self translateColor: aColor.
	(c _ self newColumn)
		parseNode: aParseNode;
		layoutInset: self standardInset;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		color: color;
		borderWidth: 1;
		borderColor: c stdBorderColor;
		wrapCentering: #topLeft;
		cellPositioning: #topLeft.
	^c
