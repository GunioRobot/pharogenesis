swapColors
	| oldBorderColor |
	oldBorderColor _ self borderColor.
	self borderColor: self secondBorderColor.
	self secondBorderColor: oldBorderColor