setWidth: value
	self resize: {value / self width asFloat. 1.0. 1.0} duration: rightNow.
