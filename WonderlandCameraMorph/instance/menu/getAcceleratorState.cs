getAcceleratorState
	^self accelerationEnabled
		ifTrue:['<on>hardware acceleration']
		ifFalse:['<off>hardware acceleration']
