changeFont
	"open a dialog to change the receiver's font"
	| newFont |
	newFont := StrikeFont fromUser: self font.
	""
	newFont isNil
		ifFalse: [self font: newFont]