handlesMouseDown: evt
	^ evt buttons noMask: 16r78  "ie no modifier keys pressed"