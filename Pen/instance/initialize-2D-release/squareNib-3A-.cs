squareNib: widthInteger 
	"Sets this pen to draw with a square tip of width widthInteger."

	self sourceForm: (Form extent: widthInteger @widthInteger) fillBlack.
	self combinationRule: Form over.  "A bit faster than paint mode"