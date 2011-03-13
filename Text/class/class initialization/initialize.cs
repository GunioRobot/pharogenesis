initialize	
	"Initialize constants shared by classes associated with text display."

	(Smalltalk includes: TextConstants) 
		ifFalse: [Smalltalk at: #TextConstants put: (Dictionary new: 32)].
	TextConstants at: #CaretForm  
		 		 put: (Cursor
	extent: 16@16
	fromArray: #(
		2r00110000000
		2r00110000000
		2r01111000000
		2r11111100000
		2r11001100000
		2r0
		2r0
		2r0
		2r0
		2r0
		2r0
		2r0
		2r0
		2r0
		2r0
		2r0)
	offset: 8@0).

	self initTextConstants.
	self initDefaultFontsAndStyle

	"Text initialize"