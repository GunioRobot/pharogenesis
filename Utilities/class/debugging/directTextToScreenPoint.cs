directTextToScreenPoint
	"Answer a point at which to put debugging info.  2/14/96 sw"
	| pointToReturn box nextPoint |
	DirectTextToScreenPoint == nil ifTrue:
		[DirectTextToScreenPoint _ 10 @ 10].
	pointToReturn _ DirectTextToScreenPoint.
	nextPoint _ DirectTextToScreenPoint + (0 @ 20).
	box _ DisplayScreen boundingBox.
	nextPoint v > (box bottom - 30)
		ifTrue:
			[nextPoint _ (nextPoint x + 300) @ 10].
	nextPoint h > (box right - 200)
		ifTrue:
			[nextPoint _ 10 @ 10].
	DirectTextToScreenPoint _ nextPoint.
	^ pointToReturn