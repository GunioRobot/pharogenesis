initializeToStandAlone 
	"Default creation is for one person against Squeak."

	super initializeToStandAlone.
	self extent: 382@413.
	self color: (Color r: 0.6 g: 0.4 b: 0.0).
	self borderWidth: 2.
	animateMoves _ true.
	self teams: #(2 5) autoPlay: {false. true}.
