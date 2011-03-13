colorUnder
	"Return the color of under the receiver's reference position."

	self isInWorld
		ifTrue: [^ self world colorAt: (self pointInWorld: self referencePosition) belowMorph: self]
		ifFalse: [^ self color].
