copyWithoutAll: aList
	"Answer a copy of the receiver that does not contain any elements equal
	to those in aList."

	^ self select: [:each | (aList includes: each) not]