showLabelled: labelString
	modal := false.
	self label: labelString.
	^(self window)
		openInWorldExtent: self defaultExtent;
		yourself