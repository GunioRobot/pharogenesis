decimalPlaces
	"Answer the number of decimal places to show."

	| places |
	(places _ self valueOfProperty: #decimalPlaces) ifNotNil: [^ places].
	self setProperty: #decimalPlaces toValue: (places _ Utilities decimalPlacesForFloatPrecision: self floatPrecision).
	^ places