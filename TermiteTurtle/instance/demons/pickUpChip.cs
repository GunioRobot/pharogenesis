pickUpChip
	"Pick up a wood chip from the current patch."

	self increment: 'woodChips' by: -1.
	isCarryingChip := true.
	self color: Color red.

