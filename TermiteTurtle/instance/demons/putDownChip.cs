putDownChip
	"Drop the wood chip I'm carrying on the current patch."

	self increment: 'woodChips' by: 1.
	isCarryingChip := false.
	self color: Color blue.

