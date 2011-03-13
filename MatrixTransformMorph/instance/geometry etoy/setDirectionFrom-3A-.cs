setDirectionFrom: aPoint
	| delta degrees |
	delta := (self transformFromWorld globalPointToLocal: aPoint) - super rotationCenter.
	degrees := delta degrees + 90.0.
	self forwardDirection: (degrees \\ 360) rounded.
