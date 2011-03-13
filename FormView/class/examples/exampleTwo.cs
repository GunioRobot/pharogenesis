exampleTwo
	"Frame a Form (specified by the user) that is scaled by 2. The border is 2 bits in width. Displays at location 60, 40."
	| f view |
	f := Form fromUser.
	view := self new model: f.
	view scaleBy: 2.0.
	view translateBy: 60 @ 40.
	view borderWidth: 2.
	view display.
	view release

	"FormView exampleTwo"