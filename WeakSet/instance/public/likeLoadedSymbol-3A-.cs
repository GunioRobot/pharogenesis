likeLoadedSymbol: anObject
	"Answer an object in the receiver that is equal to anObject,
	nil if no such object is found. Relies heavily on hash properties"

	| index element |

	^(index _ self scanForLoadedSymbol: anObject) = 0
		ifFalse: [(element _ array at: index) == flag ifFalse: [element]]