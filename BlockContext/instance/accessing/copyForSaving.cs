copyForSaving
	"Fix the values of the temporary variables used in the block that are 
	ordinarily shared with the method in which the block is defined."

	home := home copy.
	home swapSender: nil