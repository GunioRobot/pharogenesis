initializeForWeek: aWeek month: aMonth tileRect: rect model: aModel

	super initialize.
	tileRect _ rect.
	self 
		layoutInset: 0;
		color: Color transparent;
		listDirection: #leftToRight;
		hResizing: #shrinkWrap;
		disableDragNDrop;
		height: tileRect height.

	self week: aWeek month: aMonth model: aModel
