setVariables
	tool _ #repeatCopy.
	previousTool _ tool.
	grid _ 1 @ 1.
	togglegrid _ 8 @ 8.
	xgridOn _ false.
	ygridOn _ false.
	mode _ Form over.
	form _ Form extent: 8 @ 8.
	form fillBlack.
	unNormalizedColor _ color _ Color black.
	hasUnsavedChanges := ValueHolder new contents: false.
