asPickerAt: aPoint extent: extentPoint
	| picker |
	picker _ B3DPickerEngine new.
	picker loadFrom: self.
	picker pickAt: aPoint extent: extentPoint.
	^picker