indexed: item doBlocks: blocks
	"According to item's key evaluate one of the blocks with item's value"

	(blocks at: item key) value: item value