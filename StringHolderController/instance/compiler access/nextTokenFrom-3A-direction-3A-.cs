nextTokenFrom: start direction: dir
	"Basically, find where to place a period before start"
	| loc str |
	loc _ start + dir.
	str _ paragraph text string.
	[(loc between: 1 and: str size) and: [(str at: loc) isSeparator]]
		whileTrue: [loc _ loc + dir].
	^ loc