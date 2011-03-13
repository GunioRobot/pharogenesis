containsPoint: aPoint
	"Answer true only if on edges."
	
	|w|
	^(super containsPoint: aPoint) and: [
		w := SystemWindow borderWidth.
		((self bounds translateBy: w@w)
			containsPoint: aPoint) not]