exampleOne
	"Frame a Form (specified by the user) with a border of 2 bits in width and display it offset 60 x 40 from the cornor of the display screen. "
	| f view |
	f _ Form fromUser.
	view _ self new model: f.
	view translateBy: 60 @ 40.
	view borderWidth: 2.
	view display.
	view release

	"FormView exampleOne"