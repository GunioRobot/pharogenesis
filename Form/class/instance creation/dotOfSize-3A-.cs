dotOfSize: diameter
	"Create a form which contains a round black dot."
	| radius form bite circle |
	radius _ diameter//2.
	form _ Form extent: diameter@diameter offset: (0@0) - (radius@radius).	
	diameter <= 9 ifTrue: "special case for speed"
		[form fillBlack.
		bite _ diameter//3.
		form fillWhite: (0@0 extent: bite@1).
		form fillWhite: (0@(diameter-1) extent: bite@1).
		form fillWhite: (diameter-bite@0 extent: bite@1).
		form fillWhite: (diameter-bite@(diameter-1) extent: bite@1).
		form fillWhite: (0@0 extent: 1@bite).
		form fillWhite: (0@(diameter-bite) extent: 1@bite).
		form fillWhite: (diameter-1@0 extent: 1@bite).
		form fillWhite: (diameter-1@(diameter-bite) extent: 1@bite).
		^ form].

	radius _ diameter-1//2.  "so circle fits entirely"
	(Circle new center: radius@radius radius: radius) displayOn: form.
	form convexShapeFill: form black.	"fill the circle with black"
	^ form

	"(Form dotOfSize: 8) displayAt: Sensor cursorPoint"