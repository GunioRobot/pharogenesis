emitAs: stack on: strm value: forValue 
	" {...} as: .. -- handoff to receiver, which already incorporates argument."

	forValue
		ifTrue: [receiver emitForValue: stack on: strm]
		ifFalse: [receiver emitForEffect: stack on: strm]