rotateBy: direction centerAt: c
	"Answer a Point which is receiver rotated according to the direction, either #right or #left, center at point c"
	| offset |
	offset _ self - c.
	^ direction == #right 
		ifTrue: [offset y negated @ offset x + c]
		ifFalse: [offset y @ offset x negated + c]