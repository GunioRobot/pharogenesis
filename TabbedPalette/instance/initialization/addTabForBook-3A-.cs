addTabForBook: aBook
	| aTab |
	aTab _ tabsMorph addTabForBook: aBook.
	pages add: aBook.
	currentPage ifNil: [currentPage _ aBook].
	^ aTab