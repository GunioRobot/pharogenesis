togglexGridding
	"Turn x (horizontal) gridding off, if it is on, and turns it on, if it is off. 
	Does not change the primary tool."

	xgridOn
		ifTrue: 
			[grid _ 1 @ grid y.
			xgridOn _ false]
		ifFalse: 
			[grid _ togglegrid x @ grid y.
			xgridOn _ true].
	tool _ previousTool