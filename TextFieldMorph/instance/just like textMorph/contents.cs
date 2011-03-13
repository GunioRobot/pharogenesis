contents
	| tm |
	"talk to my text"

	(tm _ self findA: TextMorph) ifNil: [^ nil].
	^ tm contents