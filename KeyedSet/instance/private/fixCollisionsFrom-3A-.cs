fixCollisionsFrom: index
	"The element at index has been removed and replaced by nil.
	This method moves forward from there, relocating any entries
	that had been placed below due to collisions with this one"
	| length oldIndex newIndex element |
	oldIndex _ index.
	length _ array size.
	[oldIndex = length
			ifTrue: [oldIndex _  1]
			ifFalse: [oldIndex _  oldIndex + 1].
	(element _ self keyAt: oldIndex) == nil]
		whileFalse: 
			[newIndex _ self findElementOrNil: (keyBlock value: element).
			oldIndex = newIndex ifFalse: [self swap: oldIndex with: newIndex]]