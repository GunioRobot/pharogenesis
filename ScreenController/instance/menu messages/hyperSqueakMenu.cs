hyperSqueakMenu 
	"Put up a popup of HyperSqueak-related menu items.  7/24/96 sw"

	(Smalltalk at: #SqueakSupport ifAbsent: [^ self beep]) offerHyperSqueakMenu