newColorMap 
	"Return an uninitialized color map array appropriate to this depth form.
	Note that RBG forms may want 4k or 32k maps instead of the min 512"
	^ Bitmap new: (1 bitShift: (depth min: 9))