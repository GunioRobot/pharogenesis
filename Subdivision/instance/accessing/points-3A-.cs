points: pointCollection

	| min max |
	pointCollection isEmpty ifTrue:[
		min := -1.0@-1.0.
		max := 1.0@1.0.
	] ifFalse:[
		min := max := pointCollection anyOne.
		pointCollection do:[:p|
			min := min min: p.
			max := max max: p]].
	self withSize: (min corner: max).
	pointCollection do:[:p| self insertPoint: p].