restoreOverlap
	"Put back the transparentPixelValue in theForm where the mask is tansparent (white).  Undo what removeOverlap did.  Current transparent area must not have any colors in it now (must be 0).  Modifies the theForm.  6/20/96 tk."

	transparentPixelValue == nil ifTrue: [
		^ self error: 'Don''t know what color it was.'].
	mask reverse.
	mask displayOn: theForm
		at: 0@0
		clippingBox: theForm boundingBox
		rule: Form paint
		fillColor: (Color new pixelValue: transparentPixelValue 
			toBitPatternDepth: theForm depth).
	mask reverse.	"back to original"
	transparentPixelValue _ nil.