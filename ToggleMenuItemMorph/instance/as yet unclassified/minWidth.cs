minWidth
	"Plus the key text if any."
	
	|w|
	w := super minWidth.
	self keyText ifNotNil: [w := w + (self fontToUse widthOfString: self keyText) + 12].
	^w