magnify: aRectangle by: scale 
	"Answer an MaskedForm created as a multiple of the receiver; the result is smaller. Each bit in the new form corresponds to scale number of bits in the receiver."

	^ MaskedForm new setForm: (theForm magnify: aRectangle by: scale)
		mask: (mask magnify: aRectangle by: scale)
		removeOverlap: false transpPixVal: transparentPixelValue