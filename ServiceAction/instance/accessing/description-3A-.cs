description: anObject
	description := anObject select: [:each | (each = Character cr) not] 
						thenCollect: [:each | each = Character tab ifTrue: [Character space]
															ifFalse: [each]].