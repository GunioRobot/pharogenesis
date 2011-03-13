flipBy: direction centerAt: aPoint 
	"Return a copy flipped according to the direction, either #vertical or #horizontal, around aPoint."
	^ Rectangle
		origin: ((direction == #vertical
					ifTrue: [self bottomLeft]
					ifFalse: [self topRight])
				flipBy: direction centerAt: aPoint)
		extent: self extent