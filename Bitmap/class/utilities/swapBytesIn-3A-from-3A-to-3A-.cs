swapBytesIn: aNonPointerThing from: start to: stop
	"Perform a bigEndian/littleEndian byte reversal of my words.
	We only intend this for non-pointer arrays.  Do nothing if I contain pointers."
	| hack blt |
	"The implementation is a hack, but fast for large ranges"
	hack _ Form new hackBits: aNonPointerThing.
	blt _ (BitBlt toForm: hack) sourceForm: hack.
	blt combinationRule: Form reverse.  "XOR"
	blt sourceY: start-1; destY: start-1; height: stop-start+1; width: 1.
	blt sourceX: 0; destX: 3; copyBits.  "Exchange bytes 0 and 3"
	blt sourceX: 3; destX: 0; copyBits.
	blt sourceX: 0; destX: 3; copyBits.
	blt sourceX: 1; destX: 2; copyBits.  "Exchange bytes 1 and 2"
	blt sourceX: 2; destX: 1; copyBits.
	blt sourceX: 1; destX: 2; copyBits.
