acceptValueFromTarget: v
	"Accept a value from the target"

	self flag: #yo.  "we may want to translate the v asString result."
	lastValue _ v.
	self format == #string ifTrue: [^ v asString].
	self format == #symbol ifTrue: [^ v asString translated].
	(format == #default and: [v isNumber]) ifTrue:
		[^ v printShowingDecimalPlaces: self decimalPlaces].
	^ v printString translated.
