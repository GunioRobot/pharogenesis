targetPoint: aPoint
	"Set the reference point of the target."

	|minExt rect|
	rect := self target bounds withSideOrCorner: self edgeName setToPoint: aPoint.
	minExt := self target minimumExtent.
	rect width <= minExt x ifTrue: [
		rect := self edgeName = #left
			ifTrue: [rect withSideOrCorner: #left setToPoint: self target bounds bottomRight - minExt]
			ifFalse: [rect withSideOrCorner: #right setToPoint: self target bounds topLeft + minExt]].
	rect height <= minExt y ifTrue: [
		rect := self edgeName = #top
			ifTrue: [rect withSideOrCorner: #top setToPoint: self target bounds bottomRight - minExt]
			ifFalse: [rect withSideOrCorner: #bottom setToPoint: self target bounds topLeft + minExt]].
	self target bounds: rect