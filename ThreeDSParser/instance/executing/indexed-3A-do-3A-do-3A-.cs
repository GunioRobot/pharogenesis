indexed: item do: firstBlock do: secondBlock 
	"According to item's key evaluate one of the blocks with item's value"

	self indexed: item doBlocks: (Array with: firstBlock with: secondBlock)