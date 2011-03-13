deleteSuffixArrow

	suffixArrow delete.
	suffixArrow _ nil.
	retractArrow ifNotNil: ["backward compat"
		retractArrow delete.
		retractArrow _ nil].
	self updateLiteralLabel