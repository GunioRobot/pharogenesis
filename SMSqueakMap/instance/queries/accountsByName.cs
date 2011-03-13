accountsByName
	"Return the accounts sorted by their name."

	^self accounts asSortedCollection: [:x :y | x name caseInsensitiveLessOrEqual: y name].