isFillAccelerated: ruleInteger for: aColor
	"Return true if the receiver can perform accelerated fill operations by itself.
	It is assumed that the hardware can accelerate plain color fill operations."
	^ruleInteger = Form over and:[aColor isColor]