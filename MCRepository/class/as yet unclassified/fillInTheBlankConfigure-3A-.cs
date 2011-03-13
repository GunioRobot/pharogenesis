fillInTheBlankConfigure: aTemplateString
	| chunk repo |
	
	aTemplateString ifNil: [ ^ false ].
	chunk := FillInTheBlankMorph 
			request: self fillInTheBlankRequest
			initialAnswer: aTemplateString
			centerAt: Sensor cursorPoint
			inWorld: World
			onCancelReturn: nil
			acceptOnCR: false
			answerExtent: 400@120.
			
	chunk 
		ifNotNil: [ 
			repo := self readFrom: chunk readStream.
			repo creationTemplate: chunk. 
	].

	^ repo