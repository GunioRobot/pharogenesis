cardIndexOf: aCard
	"Answer the ordinal position of aCard in the receiver's list"

	^ cards indexOf: aCard ifAbsent: [nil]