selection
	"a selection was made on the board; get its count and update the displays"

	| count score |
	count _ self board selectionCount.
	count = 0 ifTrue:
		[score _ scoreDisplay value + (selectionDisplay value - 2) squared.
		board findSelection ifNil:
			[count _ board tilesRemaining.
			count = 0
				ifTrue: [score _ score + (5 * board rows * board columns)]
				ifFalse: [score _ score - count].
			scoreDisplay flash: true].
		scoreDisplay value: score].
	selectionDisplay value: count.