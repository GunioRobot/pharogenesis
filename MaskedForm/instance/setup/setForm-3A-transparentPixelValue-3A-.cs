setForm: aForm transparentPixelValue: pixVal
	"Create a MaskedForm with transparent where aColor is.  Substitute 0 into theForm where the mask is 1.  6/21/96 tk"

	theForm _ aForm.
	transparentPixelValue _ pixVal.
	mask _ Form extent: theForm extent offset: theForm offset.
	  "Copy the figure, depth 1"
	colorMap _ Bitmap new: (1 bitShift: theForm depth) withAll: 1.
	colorMap at: transparentPixelValue+1 put: 0.
	mask copyBits: mask boundingBox from: theForm 
		at: 0@0 colorMap: colorMap.

	"Erase the color pixelValues where theForm needs to be transparent"
	transparentPixelValue = 0 ifFalse: [self removeOverlap].
		