accountsByName
	"Return the accounts sorted by their name."

	^(SortedCollection sortBlock: [:x :y | x name <= y name])
		addAll: self accounts;
		yourself