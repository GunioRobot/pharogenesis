selectedMessage
	"Answer the source method for the currently selected message."
	self setClassAndSelectorIn:
			[:class :selector | ^ class sourceMethodAt: selector]