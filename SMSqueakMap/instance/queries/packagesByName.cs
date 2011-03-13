packagesByName
	"Return the packages sorted by their name."

	^self packages asSortedCollection: [:x :y | x name caseInsensitiveLessOrEqual: y name]