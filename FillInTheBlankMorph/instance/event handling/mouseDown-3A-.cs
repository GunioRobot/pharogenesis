mouseDown: evt
	(self containsPoint: evt position) ifFalse:[^ Beeper beep]. "sent in response to outside modal click"
	evt hand grabMorph: self. "allow repositioning"