beWordConstituent
	predicate := [:char | char isAlphaNumeric].
	negation := [:char | char isAlphaNumeric not]