setDepth: value
	self resize: {1.0. 1.0. value / self depth asFloat} duration: rightNow.
