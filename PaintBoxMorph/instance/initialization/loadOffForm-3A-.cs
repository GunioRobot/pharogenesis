loadOffForm: pic16Bit 
	"Prototype loadOffForm: (Smalltalk imageImports at: #offPaletteJapanese)"

	| blt |
	OriginalBounds _ pic16Bit boundingBox.
	AllOffImage _ Form extent: OriginalBounds extent depth: 16.
	blt _ BitBlt current toForm: AllOffImage.
	blt sourceForm: pic16Bit;
		 combinationRule: Form over;
		 sourceRect: OriginalBounds;
		 destOrigin: 0 @ 0;
		 copyBits.
	AllOffImage mapColor: Color blue to: Color transparent.
	self image: AllOffImage.
	AllOffImage _ nil.
	self invalidRect: bounds
