initInFrame: rect
	frame := rect insetBy: 2.  "Leave room for border"
	para := Paragraph withText: self contents asText
				style: TextStyle default
				compositionRectangle: ((frame insetBy: 4) withHeight: 9999)
				clippingRectangle: frame
				foreColor: self black backColor: self white