initializeForWeek: aWeek month: aMonth

	super initialize.
	self inset: 0;
		color: Color transparent;
		orientation: #horizontal;
		disableDragNDrop;
		height: 19.
	self week: aWeek month: aMonth
