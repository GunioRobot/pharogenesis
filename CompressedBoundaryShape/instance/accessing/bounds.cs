bounds
	| min max width |
	points isEmpty ifTrue:[^0@0 corner: 1@1].
	min _ max _ points first.
	points do:[:pt|
		min _ min min: pt.
		max _ max max: pt
	].
	width _ 0.
	lineWidths valuesDo:[:w| width _ width max: w].
	^(min corner: max) insetBy: (width negated asPoint)