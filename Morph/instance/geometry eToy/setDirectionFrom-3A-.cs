setDirectionFrom: aPoint
	| delta degrees |
	delta _ (self transformFromWorld globalPointToLocal: aPoint) - self referencePosition.
	degrees _ delta degrees + 90.0.
	self forwardDirection: (degrees \\ 360) rounded.
