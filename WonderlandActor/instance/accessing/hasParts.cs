hasParts
	"Return true if the receiver has any children that are parts"

	self partsDo: [:child | ^ true ].

	^ false.
