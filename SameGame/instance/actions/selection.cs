selection
	"a selection was made on the board; get its count and update the displays"

	| count score |
	count := self board selectionCount.
	count = 0 
		ifTrue: 
			[score := scoreDisplay value + (selectionDisplay value - 2) squared.
			board findSelection ifNil: 
					[count := board tilesRemaining.
					score := count = 0 
						ifTrue: [score + (5 * board rows * board columns)]
						ifFalse: [score - count].
					scoreDisplay flash: true].
			scoreDisplay value: score].
	selectionDisplay value: count