beAStackBackground
	"Transform the receiver into one that has stack-background behavior.  If just becoming a stack, allocate a uniclass to represent the cards (if one does not already exist"

	self assuredPlayer assureUniClass.
	self setProperty: #tabAmongFields toValue: true.
	self setProperty: #stackBackground toValue: true.
	self reassessBackgroundShape