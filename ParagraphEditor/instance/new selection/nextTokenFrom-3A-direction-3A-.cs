nextTokenFrom: start direction: dir
	"simple token-finder for compiler automated corrections"
	| loc str |
	loc _ start + dir.
	str _ paragraph text string.
	[(loc between: 1 and: str size) and: [(str at: loc) isSeparator]]
		whileTrue: [loc _ loc + dir].
	^ loc