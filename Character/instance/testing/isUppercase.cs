isUppercase
	"Answer whether the receiver is an uppercase letter.
	(The old implementation answered whether the receiver is not a lowercase letter.)"

	^8r101 <= value and: [value <= 8r132]