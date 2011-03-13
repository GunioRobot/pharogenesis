loadPressedImage: fileName
	"Read in and convert the image for the paintBox with the buttons
on.  A .bmp 24-bit image.  For each button, cut that chunk out and save it."
	"	self loadPressedImage: 'NoSh:=on.bmp'.
		AllPressedImage := nil.	'save space'.	"

	| pic16Bit blt aa on type |
	type := 'gif'.  "   gif or bmp  "
type = 'gif' ifTrue: [
	pic16Bit "really 8" := GIFReadWriter formFromFileNamed: fileName.
	pic16Bit display.
	aa := AllPressedImage := Form extent: OriginalBounds extent depth: 8.
	blt := BitBlt current toForm: aa.
	blt sourceForm: pic16Bit; combinationRule: Form over;
		sourceRect: OriginalBounds; destOrigin: 0@0; copyBits.
	].
type = 'bmp' ifTrue: [
	pic16Bit := (Form fromBMPFileNamed: fileName) asFormOfDepth: 16.
	pic16Bit display.
	aa := AllPressedImage := Form extent: OriginalBounds extent depth: 16.
	blt := BitBlt current toForm: aa.
	blt sourceForm: pic16Bit; combinationRule: Form over;
		sourceRect: OriginalBounds; destOrigin: 0@0; copyBits.
	aa mapColor: Color transparent to: Color black.
	].
	"Collect all the images for the buttons in the on state"
	self allMorphsDo: [:button |
		(button isKindOf: ThreePhaseButtonMorph) ifTrue: [
			type = 'gif' ifTrue: [on := ColorForm extent: button extent depth: 8.
					 on colors: pic16Bit colors]
				ifFalse: [on := Form extent: button extent depth: 16].
			on copy: (0@0 extent: button extent)
				from: (button topLeft - self topLeft) in: aa rule: Form over.
			button pressedImage: on]].
	self invalidRect: bounds.

	