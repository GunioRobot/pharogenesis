check: nDice difficulty: diff
	"Roll some dice, WoD-style."

	| result die |
	result _ 0.
	nDice timesRepeat: 
		[(die _ self nextInt: 10) = 1
			ifTrue: [result _ result - 1]
			ifFalse: [die >= diff ifTrue: [result _ result + 1]]].
	^ result