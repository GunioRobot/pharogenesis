makeRoomAtEnd
	| contentsSize |
	readPosition = 1
		ifTrue: 
			[contentsArray _ contentsArray , (Array new: 10)]
		ifFalse: 
			[contentsSize _ writePosition - readPosition.
			1 to: contentsSize do: 
				[:index | 
				contentsArray 
					at: index 
					put: (contentsArray at: index + readPosition - 1)].
			readPosition _ 1.
			writePosition _ contentsSize + 1]