requestText
	^ FillInTheBlankMorph 
		request: prompt
		initialAnswer: template
		centerAt: Sensor cursorPoint
		inWorld: World
		onCancelReturn: nil
		acceptOnCR: true