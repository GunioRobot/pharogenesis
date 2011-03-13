step
	"Update the image to be a thumbnail of the morph under the hand.
	Optimized to not constantly update."
	
	| current |
	current := self selectedObject.
	current == (self valueOfProperty: #currentSelectedObject)
		ifTrue: [^self].
	self setProperty: #currentSelectedObject toValue: current.
	self setBalloonText: (current isNil
				ifTrue: [noSelectedBalloonText]
				ifFalse: [current externalName]).
	""
	self makeThumbnailFrom: current