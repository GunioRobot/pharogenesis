lookForChip
	"If this terminte is not carrying a chip and there is a chip at the current location, pick up the chip. To minimize the chance of immediately enountering the same chip pile, turn around and take one step in the the opposite direction."

	(isCarryingChip not and:
	 [(self get: 'woodChips') > 0]) ifTrue: [
		self pickUpChip.
		self turnRight: 180.
		self forward: 1].
