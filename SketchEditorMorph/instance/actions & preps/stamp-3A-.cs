stamp: evt
	"plop one copy of the user's chosen Form down."

	"Check depths"
	| pt |
	pt _ evt cursorPoint - (stampForm extent // 2).
	stampForm displayOn: paintingForm 
		at: pt - bounds origin
		clippingBox: paintingForm boundingBox
		rule: Form paint
		fillColor: nil.
	self render: (pt extent: stampForm extent).
