initialize

	super initialize.
	borderWidth _ 0.
	orientation _ #horizontal.	"#horizontal or #vertical  or #free"
	centering _ #topLeft.		"#topLeft, #center, or #bottomRight"
	hResizing _ #spaceFill.		"#spaceFill, #shrinkWrap, or #rigid"
	vResizing _ #spaceFill.		"#spaceFill, #shrinkWrap, or #rigid"
	inset _ 2.					"pixels inset within owner's bounds"
	minCellSize _ 0.				"minimum space between morphs; useful for tables"
	openToDragNDrop _ false.	"objects can be dropped in or dragged out"
	layoutNeeded _ true.
	color _ Color r: 0.8 g: 1.0 b: 0.8.
