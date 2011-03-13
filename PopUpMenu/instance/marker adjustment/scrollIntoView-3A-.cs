scrollIntoView: cursorLoc
	| dy |
	dy _ 0.
	cursorLoc y < 2 ifTrue: [dy _ font height].
	cursorLoc y > (Display height-3) ifTrue: [dy _ font height negated].
	dy = 0 ifTrue: [^ 0@0].
	self markerOff.
	frame _ frame translateBy: 0@dy.
	marker _ marker translateBy: 0@dy.
	self menuForm displayOn: Display at: frame topLeft.
	^ 0@dy