row: aColor on: aParseNode

	| r color |
	color _ self translateColor: aColor.
	(r _ self newRow)
		parseNode: aParseNode;
		layoutInset: r standardInset;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		color: color;
		borderWidth: 1;
		borderColor: r stdBorderColor;
		wrapCentering: #topLeft;
		cellPositioning: r standardCellPositioning.
	^r