mouseDown: evt
	(self containsPoint: evt position) ifFalse:[^Smalltalk beep]. "sent in response to outside modal click"
	evt hand grabMorph: self. "allow repositioning"