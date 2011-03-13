updateTrailsForm
	"Update the turtle-trails form using the current positions of all turtles."
	"Details: The positions of all turtles with their pens down are recorded each time the draw method is called. If the list from the previous display cycle isn't empty, then trails are drawn from the old to the new positions of those morphs on the turtle-trails form. The turtle-trails form is created on demand when the first pen is put down and removed (to save space) when turtle trails are cleared."

	| origin m oldPoint newPoint mPenSize offset |
	origin _ self topLeft.
	turtlePen ifNil: [turtlePen _ Pen newOnForm: turtleTrailsForm].
	lastTurtlePositions associationsDo: [:assoc |
		m _ assoc key costume.
		oldPoint _ assoc value.
		newPoint _ m referencePosition.
		((m owner == self) and:
		 [m getPenDown and:
		 [newPoint ~= oldPoint]]) ifTrue:
			[mPenSize _ m getPenSize.
			turtlePen sourceForm width ~= mPenSize
				ifTrue: [turtlePen squareNib: mPenSize].
			offset _ (mPenSize // 2)@(mPenSize // 2).
			turtlePen color: m getPenColor.
			turtlePen drawFrom: (oldPoint - origin - offset) asIntegerPoint
				to: (newPoint - origin - offset) asIntegerPoint.
			self invalidRect: ((oldPoint rect: newPoint) expandBy: mPenSize)]]
