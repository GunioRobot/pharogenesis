lineCount
	| tm |
	"how many lines in my text"

	(tm _ self findA: TextMorph) ifNil: [^ nil].
	^ tm contents string lineCount