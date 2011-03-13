togglexGridding
	"Turn x (horizontal) gridding off, if it is on, and turns it on, if it is off. 
	Does not change the primary tool."

	xgridOn
		ifTrue: 
			[grid := 1 @ grid y.
			xgridOn := false]
		ifFalse: 
			[grid := togglegrid x @ grid y.
			xgridOn := true].
	tool := previousTool