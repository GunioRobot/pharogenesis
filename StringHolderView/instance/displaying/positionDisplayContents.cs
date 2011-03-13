positionDisplayContents
	"Presumably the text being displayed changed so that the wrapping box 
	and clipping box should be reset."

	displayContents 
		wrappingBox: (self insetDisplayBox insetBy: 6 @ 0)
		clippingBox: self insetDisplayBox