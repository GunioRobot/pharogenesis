displayView
	"Refer to the comment in View|displayView. "
	labelFrame height = 0 ifTrue: [^ self].  "no label"
	self displayBox width = labelFrame width ifFalse:
		["recompute label width when window changes size"
		self setLabelRegion].
	(labelFrame align: labelFrame topLeft with: self windowOrigin)
		insideColor: self labelColor;
		displayOn: Display.
	self displayLabelText