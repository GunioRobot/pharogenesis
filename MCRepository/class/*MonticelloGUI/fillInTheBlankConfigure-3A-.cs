fillInTheBlankConfigure: aTemplateString 
	| chunk repo |
	aTemplateString
		ifNil: [^ false].
	chunk := UIManager default
				multiLineRequest: self fillInTheBlankRequest
				centerAt: Sensor cursorPoint
				initialAnswer: aTemplateString
				answerHeight: 350.
	(chunk notNil and: [ chunk notEmpty ])
		ifTrue: [repo := self readFrom: chunk readStream.
			repo creationTemplate: chunk].
	^ repo