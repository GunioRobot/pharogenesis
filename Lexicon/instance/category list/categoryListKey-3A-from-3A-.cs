categoryListKey: aChar from: aView
	"The user hit a command-key while in the category-list.  Do something"

	(aChar == $f and: [self hasSearchPane not]) ifTrue:
		[^ self obtainNewSearchString].