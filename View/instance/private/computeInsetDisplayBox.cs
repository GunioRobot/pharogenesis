computeInsetDisplayBox
	"Compute the View's inset display box by intersecting the superView's
	inset display box with the View's window transformed to display
	coordinates and then inseting the result by the border width. It is sent by 
	View|insetDisplayBox if the inset display box is nil.

	The insetDisplayBox points are truncated to prevent sending floating point numbers to QuickDraw which will die."

	self isTopView
		ifTrue:
			[^((self displayTransform: self getWindow) insetBy: borderWidth) truncated]
		ifFalse:
			[^(superView insetDisplayBox
				intersect: (self displayTransform: self getWindow)) truncated
						insetBy: borderWidth]