setDecimalPlacesFromTypeIn: typeIn
	"The user has typed in a number as the new value of the receiver.  Glean off decimal-places-preference from the type-in"

	| decimalPointPosition tail places |
	decimalPointPosition _ typeIn indexOf: $. ifAbsent: [nil].
	places _ 0.
	decimalPointPosition
		ifNotNil:
			[tail _ typeIn copyFrom: decimalPointPosition + 1 to: typeIn size.
			[places < tail size and: [(tail at: (places + 1)) isDigit]]
				whileTrue:
					[places _ places + 1]].
		
	self decimalPlaces: places