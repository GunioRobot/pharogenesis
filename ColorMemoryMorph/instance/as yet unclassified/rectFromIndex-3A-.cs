rectFromIndex: index
	"Where is the patch of the Nth color?  Includes one pixel border."

	^ self topLeft + (index-1\\16 * cellSize x @ (index-1//16 * cellSize y)) extent: cellSize + (1@1)