makeRoomAtEnd
	| contentsSize |
	readPosition = 1
		ifTrue: [contentsArray _ contentsArray , (Array new: 10)]
		ifFalse: 
			[contentsSize _ writePosition - readPosition.
			"BLT direction ok for this. Lots faster!!!!!! SqR!! 4/10/2000 10:47"
			contentsArray
				replaceFrom: 1
				to: contentsSize
				with: contentsArray
				startingAt: readPosition.
			readPosition _ 1.
			writePosition _ contentsSize + 1]