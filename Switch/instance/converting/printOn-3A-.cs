printOn: aStream
	self isOn
		ifTrue: [aStream nextPutAll: 'ON-Switch']
		ifFalse: [aStream nextPutAll: 'OFF-Switch']