reverseDirection
	| tmp |
	1 to: self basicSize by: 3 do:[:i|
		tmp _ self basicAt: i.
		self basicAt: i put: (self basicAt: i+2).
		self basicAt: i+2 put: tmp.
	].