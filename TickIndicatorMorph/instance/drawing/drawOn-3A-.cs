drawOn: aCanvas
	| r center cc deg |
	super drawOn: aCanvas.
	corners ifNil:[
		r _ (bounds topCenter - bounds center) r - 2.
		corners _ Array new: 32.
		1 to: corners size do:[:i|
			deg _ 360.0 / corners size * (i-1).
			corners at: i put: (Point r: r degrees: deg-90) asIntegerPoint]].
	index _ index \\ corners size.
	cc _ color darker.
	center _ bounds center.
	1 to: corners size by: 4 do:[:i|
		aCanvas fillRectangle: (center + (corners at: i)-2  extent: 4@4) color: cc.
	].
	cc _ cc darker.
	aCanvas line: center to: center + (corners at: index + 1) width: 2 color: cc.