setSize: oldExtent andMakeResizable: outerMorph
	| tw |
	(tw _ outerMorph findA: TwoWayScrollPane) ifNil: [^self].
	tw hResizing: #spaceFill;
		vResizing: #spaceFill;
		color: Color transparent;
		setProperty: #hideUnneededScrollbars toValue: true.
	outerMorph 
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		cellPositioning: #topLeft.
	outerMorph fullBounds.
