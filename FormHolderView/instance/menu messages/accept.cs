accept 
	"Refer to the comment in FormView|accept."
	model
		copyBits: displayedForm boundingBox
		from: displayedForm
		at: 0 @ 0
		clippingBox: model boundingBox
		rule: Form over
		fillColor: nil.
	model changed: self