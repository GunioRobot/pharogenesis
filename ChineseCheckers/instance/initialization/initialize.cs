initialize
	"Default creation is for one person against Squeak."
	super initialize.
	""
	self extent: 382 @ 413.

	animateMoves _ true.
	self teams: #(2 5 ) autoPlay: {false. true}