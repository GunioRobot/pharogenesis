drawPenTrailFor: aMorph from: oldPoint to: targetPoint
	"Draw a pen trail for aMorph, using its pen state (the pen is assumed to be down)."
	"The turtleTrailsForm is created on demand when the first pen is put down and removed (to save space) when turtle trails are cleared."

	| origin mPenSize offset turtleTrailsDelta newPoint aPlayer trailStyle aRadius dotSize |
	turtleTrailsDelta _ self valueOfProperty: #turtleTrailsDelta ifAbsent:[0@0].
	newPoint _ targetPoint - turtleTrailsDelta.
	oldPoint = newPoint ifTrue: [^ self].
	self createOrResizeTrailsForm.
	origin _ self topLeft.
	mPenSize _ aMorph getPenSize.
	turtlePen color: aMorph getPenColor.
	turtlePen sourceForm width ~= mPenSize
		ifTrue: [turtlePen squareNib: mPenSize].
	offset _ (mPenSize // 2)@(mPenSize // 2).
	(#(lines arrows) includes: (trailStyle _ (aPlayer _ aMorph player) getTrailStyle))
		ifTrue:
			[turtlePen drawFrom: (oldPoint - origin - offset) asIntegerPoint
				to: (newPoint - origin - offset) asIntegerPoint].
	((#(arrowheads arrows) includes: trailStyle) and: [oldPoint ~= newPoint]) ifTrue:
		[turtlePen
			arrowHeadFrom: (oldPoint - origin - offset) 
			to: (newPoint - origin - offset)
			forPlayer: aPlayer].
	(#(dots) includes: trailStyle)
		ifTrue:
			[dotSize _ aPlayer getDotSize.
			turtlePen
				putDotOfDiameter: dotSize at: (oldPoint - origin).
			turtlePen
				putDotOfDiameter: dotSize at: (targetPoint - origin).
			aRadius _ (dotSize // 2) + 1.
			dotSize _ dotSize + 1.  "re round-off-derived gribblies"
			self invalidRect: ((oldPoint - origin - (aRadius @ aRadius)) extent: (dotSize @ dotSize)).
			self invalidRect: ((targetPoint - origin - (aRadius @ aRadius)) extent: (dotSize @ dotSize))]
		ifFalse:
			[self invalidRect: ((oldPoint rect: newPoint) expandBy: mPenSize)]