loadoffImage: fileName
	"Read in and convert the background image for the paintBox.  All
buttons off.  A .bmp 24-bit image."
	"	Prototype loadoffImage: 'roundedPalette3.bmp'	"

	| pic16Bit blt type getBounds |
	type _ 'bmp'.  " gif or bmp  "
	getBounds _ 'fromPic'.	"fromUser = draw out rect of paintbox on image"
		"fromOB = just read in new bits, keep same size and place as last time."
		"fromPic = picture is just the PaintBox, use its bounds"
type = 'gif' ifTrue: [
	pic16Bit "really 8" _ GIFReadWriter formFromFileNamed: fileName.
	getBounds = 'fromUser' ifTrue: ["Just first time, collect the bounds"
			pic16Bit display.
			OriginalBounds _ Rectangle fromUser].
	getBounds = 'fromPic' ifTrue: [OriginalBounds _ pic16Bit boundingBox].
	].
		"Use OriginalBounds as it was last time"
type = 'bmp' ifTrue: [
	pic16Bit _ (Form fromBMPFileNamed: fileName) asFormOfDepth: 16.
	getBounds = 'fromUser' ifTrue: ["Just first time, collect the bounds"
			pic16Bit display.
			OriginalBounds _ Rectangle fromUser].
		"Use OriginalBounds as it was last time"
	(getBounds = 'fromPic') ifTrue: [OriginalBounds _ pic16Bit boundingBox].
	AllOffImage _ Form extent: OriginalBounds extent depth: 16.
	].

type = 'gif' ifTrue: [
	AllOffImage _ ColorForm extent: OriginalBounds extent depth: 8.
	AllOffImage colors: pic16Bit colors].

	blt _ BitBlt current toForm: AllOffImage.
	blt sourceForm: pic16Bit; combinationRule: Form over;
		sourceRect: OriginalBounds; destOrigin: 0@0; copyBits.

type = 'bmp' ifTrue: [AllOffImage mapColor: Color transparent to: Color black].
	self image: AllOffImage.
	self invalidRect: bounds.

	