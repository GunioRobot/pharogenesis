packagesByName
	"Return the packages sorted by their name."

	^(SortedCollection sortBlock: [:x :y | x name <= y name])
		addAll: self packages;
		yourself