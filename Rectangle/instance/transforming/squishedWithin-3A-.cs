squishedWithin: aRectangle
	"Force the receiver to fit within aRectangle by reducing its size, not by changing its origin.  5/21/96 sw"

	self bottom: (self bottom min: aRectangle bottom).
	self right: (self right min: aRectangle right)

"(50 @ 50 corner: 160 @ 100) squishedWithin:  (20 @ 10 corner: 90 @ 85)"
