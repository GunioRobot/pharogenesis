fillPeriphery: aHalfTone
	"Fill any white areas at the periphery of this form with aHalftone."
	^ self shapeFill: aHalfTone seedBlock:
		[:form | form border: form boundingBox width: 1 rule: Form reverse fillColor: nil]