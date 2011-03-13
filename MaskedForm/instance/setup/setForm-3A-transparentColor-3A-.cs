setForm: aForm transparentColor: aColor
	"Create a MaskedForm with transparent where aColor is.  Substitute 0 into theForm where the mask is 1.  6/21/96 tk"

	| d |
	theForm _ aForm.
	aColor == nil ifTrue: [
		"no transparency, take whole form, don't mask off any of it."
		mask _ Form extent: theForm extent offset: theForm offset.
		mask fillWithColor: #black.
		^ self].
	d _ theForm depth.
	transparentPixelValue _ aColor pixelValueForDepth: d.
	mask _ Form extent: theForm extent offset: theForm offset.
	  "Copy the figure"
	colorMap _ Bitmap new: (1 bitShift: d) withAll: 1.
	colorMap at: transparentPixelValue+1 put: 0.
	mask copyBits: mask boundingBox from: theForm 
		at: 0@0 colorMap: colorMap.

	"Erase the color pixelValues where theForm needs to be transparent"
	transparentPixelValue = 0 ifFalse: [self removeOverlap].
