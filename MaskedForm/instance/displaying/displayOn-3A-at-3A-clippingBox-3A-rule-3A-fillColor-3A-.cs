displayOn: aDisplayMedium at: aDisplayPoint clippingBox: clipRectangle rule: ruleInteger fillColor: fillColor
	"This is the real display message.  Remove the area of the mask, and OR in theForm."

	(aDisplayMedium isKindOf: MaskedForm)
		ifFalse: ["aDisplayMedium is a normal Form"
			mask displayOn: aDisplayMedium
				at: aDisplayPoint
				clippingBox: clipRectangle
				rule: Form erase1bitShape
				fillColor: nil.	"Cut a hole in the picture with my mask"
			theForm displayOn: aDisplayMedium
				at: aDisplayPoint
				clippingBox: clipRectangle
				rule: Form under	"OR my picture into the hole"
				fillColor: fillColor]
		ifTrue: ["aDisplayMedium is a MaskedForm"
			mask displayOn: aDisplayMedium mask
				at: aDisplayPoint
				clippingBox: clipRectangle
				rule: Form under
				fillColor: nil.	"OR my mask into the mask"
			mask displayOn: aDisplayMedium form
				at: aDisplayPoint
				clippingBox: clipRectangle
				rule: Form erase1bitShape
				fillColor: nil.	"Cut a hole in the picture with my mask"
			theForm displayOn: aDisplayMedium form
				at: aDisplayPoint
				clippingBox: clipRectangle
				rule: Form under	"OR my picture into the hole"
				fillColor: fillColor]