lookForPile
	"If I am carrying a chip and there is a chip at the current location, drop the chip I'm carrying. To minimize the chance of immediately enountering the same chip pile, turn around and take one step in the the opposite direction."

	(isCarryingChip and:
	 [(self get: 'woodChips') > 0]) ifTrue: [
		self putDownChip.
		self turnRight: 180.
		self forward: 1].
