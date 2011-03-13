sizeAs: encoder value: forValue 
	"Only receiver generates any code."

	^forValue
		ifTrue: [receiver sizeForValue: encoder]
		ifFalse: [receiver sizeForEffect: encoder]