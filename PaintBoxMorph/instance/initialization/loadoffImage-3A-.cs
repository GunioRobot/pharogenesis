loadoffImage: fileName
	"Read in and convert the background image for the paintBox.  All
buttons off.  A .bmp 24-bit image."
	"	self loadoffImage: 'paintPal 10/13b.gif'	"

	| pic16Bit blt fromScratch type |
	type _ 'gif'.  "   gif or bmp  "
	fromScratch _ false.	"true= draw out rect of paintbox on image"
		"false= just read in new bits, keep same size and place."
type = 'gif' ifTrue: [
	pic16Bit "really 8" _ GIFReadWriter formFromFileNamed: fileName.
	fromScratch ifTrue: ["Just first time, collect the bounds"
			pic16Bit display.
			OriginalBounds _ Rectangle fromUser]].
		"Use OriginalBounds as it was last time".

type = 'bmp' ifTrue: [
	pic16Bit _ Form fromBMPFileNamed: fileName depth: 16.
	fromScratch ifTrue: ["Just first time, collect the bounds"
			pic16Bit display.
			OriginalBounds _ Rectangle fromUser].
		"Use OriginalBounds as it was last time".
	AllOffImage _ Form extent: OriginalBounds extent depth: 8.
	].
type = 'gif' ifTrue: [
	AllOffImage _ ColorForm extent: OriginalBounds extent depth: 8.
	AllOffImage colors: pic16Bit colors].

	blt _ BitBlt toForm: AllOffImage.
	blt sourceForm: pic16Bit; combinationRule: Form over;
		sourceRect: OriginalBounds; destOrigin: 0@0; copyBits.

type = 'bmp' ifTrue: [AllOffImage removeZeroPixelsFromForm].
	self image: AllOffImage.
	self invalidRect: bounds.

	