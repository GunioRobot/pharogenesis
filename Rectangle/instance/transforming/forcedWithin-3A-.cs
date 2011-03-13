forcedWithin: aRectangle
	"Force the receiver to fit within aRectangle.  1/12/96 sw
	 2/5/96 sw: don't let top or left go outside requested area

	(50 @ 50 corner: 160 @ 100) forcedWithin:
           (20 @ 10 corner: 90 @ 85) 
"
	self moveBy: ((0 @ 0) min: (aRectangle corner) - corner).
	origin _ origin max: aRectangle origin