newColorMap 
	"Return an uninitialized color map array appropriate to this Form's depth."

	^ Bitmap new: (1 bitShift: (depth min: 15))
