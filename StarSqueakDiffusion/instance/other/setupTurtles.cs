setupTurtles

	| radius t |
	dyeCount ifNil: [dyeCount _ 200].
	waterCount ifNil: [waterCount _ 2000].
	radius _ 10.
	self makeTurtles: waterCount class: DiffusionTurtle.
	turtles do: [:each |
		each color: (Color gray: 0.7).
		(each distanceTo: 50@50) < radius ifTrue: [each die]].

	self makeTurtles: dyeCount class: DiffusionTurtle.
	turtles size - (dyeCount - 1) to: turtles size do: [:i |
		t _ turtles at: i.
		t goto: 50@50.
		t forward: (self random: radius).
		t color: Color green darker darker].
