next
	| character |
	character := sourceStream next.
	sourceStream position - 1 == lastPosition 
		ifTrue: 
			[lastPosition := lastPosition + 1.
			character == Character cr 
				ifTrue: 
					[eolPositions add: sourceStream position.
					previousWasCR := true]
				ifFalse: 
					[(previousWasCR not and: [character == Character lf]) 
						ifTrue: [eolPositions add: sourceStream position].
					previousWasCR := false]].
	^character