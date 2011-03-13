printOn: aStream 
	self seconds = 0
		ifTrue: [self print24: false showSeconds: false on: aStream]
		ifFalse: [self print24: false on: aStream]