setVariables
	tool := #repeatCopy.
	previousTool := tool.
	grid := 1 @ 1.
	togglegrid := 8 @ 8.
	xgridOn := false.
	ygridOn := false.
	mode := Form over.
	form := Form extent: 8 @ 8.
	form fillBlack.
	unNormalizedColor := color := Color black.
	hasUnsavedChanges := ValueHolder new contents: false.
