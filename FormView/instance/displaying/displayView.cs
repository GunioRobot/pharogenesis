displayView 
	"Refer to the comment in View|displayView."

	| oldOffset |
	super displayView.
	insideColor == nil ifFalse: [Display fill: self insetDisplayBox fillColor: insideColor].
	oldOffset _ model offset.
	model offset: "borderWidth origin" 0@0.
	model
		displayOn: Display
		transformation: self displayTransformation
		clippingBox: self insetDisplayBox
		rule: self rule
		fillColor: self fillColor.
	model offset: oldOffset