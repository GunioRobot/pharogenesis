rotateBy: direction centerAt: aPoint
	"Return a copy rotated either #right or #left around aPoint"
	^ Rectangle origin: ((origin rotateBy: direction centerAt: aPoint) - (direction == #right ifTrue: [self height @ 0] 
	ifFalse: [0 @ self width])) extent: self extent transpose	
		"origin becomes new topRight then offset to origin"