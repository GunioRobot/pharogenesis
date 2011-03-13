flipBy: direction centerAt: c
	"Answer a Point which is receiver flipped according to the direction, either #vertical or #horizontal, center at point c"
	^ direction == #vertical 
		ifTrue: [x @ (c y * 2 - y)]
		ifFalse: [(c x * 2 - x) @ y]