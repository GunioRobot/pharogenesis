accountsByInitials
	"Return the accounts sorted by the developer initials."

	^(SortedCollection sortBlock: [:x :y | x initials <= y initials])
		addAll: self accounts;
		yourself