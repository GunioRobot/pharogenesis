roundedCornersString
	^ ((self valueOfFlag: #roundedWindowCorners)
		ifFalse:
			['start']
		ifTrue:
			['stop']), ' rounding window corners'