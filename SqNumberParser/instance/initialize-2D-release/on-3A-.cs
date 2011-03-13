on: aStringOrStream
	sourceStream := aStringOrStream isString
		ifTrue: [ReadStream on: aStringOrStream]
		ifFalse: [aStringOrStream].
	base := 10.
	neg := false.
	integerPart := fractionPart := exponent := scale := 0.
	requestor := failBlock := nil.