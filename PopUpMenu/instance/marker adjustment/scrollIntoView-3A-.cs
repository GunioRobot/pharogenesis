scrollIntoView: cursorLoc
	| dy |
	dy _ 0.
	cursorLoc y < 0 ifTrue: [dy _ font height].
	cursorLoc y > Display height ifTrue: [dy _ font height negated].
	dy = 0 ifTrue: [^ 0@0].
	self markerOff.
	frame moveBy: 0@dy.
	marker moveBy: 0@dy.
	form displayOn: Display at: frame topLeft.
	^ 0@dy