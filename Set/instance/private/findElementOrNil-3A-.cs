findElementOrNil: anObject
	"Answer the index of a first slot containing either a nil (indicating an empty slot) or an element that matches the given object. Answer the index of that slot or zero. Fail if neither a match nor an empty slot is found."

	| start index length |
	"search from (hash mod size) to the end"
	length _ array size.
	start _ (anObject hash \\ length) + 1.
	index _ self scanFor: anObject from: start to: length.
	index > 0 ifTrue: [ ^ index ].

	"search from 1 to where we started"
	index _ self scanFor: anObject from: 1 to: start - 1.
	index > 0 ifTrue: [ ^ index ].

	"Bad scene.  Neither have we found a matching element
	nor even an empty slot.  No hashed set is ever supposed to get
	completely full."
	self error: 'There is no free space in this set!'.