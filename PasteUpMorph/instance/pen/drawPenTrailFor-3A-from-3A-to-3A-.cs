drawPenTrailFor: aMorph from: oldPoint to: targetPoint
	"Draw a pen trail for aMorph, using its pen state (the pen is assumed to be down)."
	"The turtleTrailsForm is created on demand when the first pen is put down and removed (to save space) when turtle trails are cleared."
	| origin mPenSize offset turtleTrailsDelta newPoint |
	turtleTrailsDelta _ self valueOfProperty: #turtleTrailsDelta ifAbsent:[0@0].
	newPoint _ targetPoint - turtleTrailsDelta.
	oldPoint = newPoint ifTrue:[^self].
	self createOrResizeTrailsForm.
	origin _ self topLeft.
	mPenSize _ aMorph getPenSize.
	turtlePen sourceForm width ~= mPenSize
		ifTrue: [turtlePen squareNib: mPenSize].
	offset _ (mPenSize // 2)@(mPenSize // 2).
	turtlePen color: aMorph getPenColor.
	turtlePen drawFrom: (oldPoint - origin - offset) asIntegerPoint
				to: (newPoint - origin - offset) asIntegerPoint.
	self invalidRect: ((oldPoint rect: newPoint) expandBy: mPenSize)
