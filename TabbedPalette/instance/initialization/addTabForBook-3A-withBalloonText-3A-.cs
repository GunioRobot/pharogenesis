addTabForBook: aBook withBalloonText: text
	| aTab |
	aTab _ tabsMorph addTabForBook: aBook.
	pages add: aBook.
	currentPage ifNil: [currentPage _ aBook].
	text ifNotNil: [aTab setBalloonText: text].
	^ aTab