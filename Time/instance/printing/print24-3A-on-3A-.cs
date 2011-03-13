print24: hr24 on: aStream 
	"Format is 'hh:mm:ss' or 'h:mm:ss am' "
	hr24
	ifTrue:
		[hours < 10 ifTrue: [aStream nextPutAll: '0'].
		hours printOn: aStream]
	ifFalse:
		[hours > 12
		ifTrue: [hours - 12 printOn: aStream]
		ifFalse: [hours < 1
				ifTrue: [12 printOn: aStream]
				ifFalse: [hours printOn: aStream]]].
	aStream nextPutAll: (minutes < 10 ifTrue: [':0']
									  ifFalse: [':']).
	minutes printOn: aStream.
	aStream nextPutAll: (seconds < 10 ifTrue: [':0']
									  ifFalse: [':']).
	seconds printOn: aStream.
	hr24 ifFalse:
		[ aStream nextPutAll: (hours < 12 ifTrue: [' am']
										ifFalse: [' pm'])]