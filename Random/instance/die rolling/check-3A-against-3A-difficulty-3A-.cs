check: nAttack against: nDefend difficulty: diff
	"Roll some dice, WoD-style."

	| attacks defends |
	attacks _ self check: nAttack difficulty: diff.
	attacks < 0 ifTrue: [^ attacks].
	defends _ self check: nDefend difficulty: diff.
	^ attacks - defends min: 0