removeOverlap
	"Erase everything in theForm where the mask is tansparent (white).  Often what you want when theForm is more than one bit deep.  Modifies the theForm.  6/20/96 tk."

	mask reverse.
	mask displayOn: theForm
		at: 0@0
		clippingBox: theForm boundingBox
		rule: Form erase1bitShape
		fillColor: nil.
	mask reverse.	"back to original"
