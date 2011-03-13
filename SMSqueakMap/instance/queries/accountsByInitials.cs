accountsByInitials
	"Return the accounts sorted by the developer initials."

	^self accounts asSortedCollection: [:x :y | x initials caseInsensitiveLessOrEqual: y initials]