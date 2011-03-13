step
	"Send the selected message in the accessed method, and regain control 
	after the invoked method returns."
	
	| currentContext oldMethod |
	self okToChange ifFalse: [^ self].
	self checkContextSelection.
	externalInterrupt ifFalse: [contextStackTop push: proceedValue].
	externalInterrupt _ true. "simulation leaves same state as interrupting"
	currentContext _ self selectedContext.
	self contextStackIndex > 1
		ifTrue: 
			[currentContext completeCallee: contextStackTop.
			self resetContext: currentContext]
		ifFalse: 
			[currentContext stepToSendOrReturn.
			currentContext willReturn
				ifTrue: 
					[oldMethod _ currentContext method.
					currentContext _ currentContext step.
					currentContext stepToSendOrReturn.
					self resetContext: currentContext.
					oldMethod == currentContext method "didnt used to update pc here"
						ifTrue: [self changed: #pc]]
				ifFalse: 
					[currentContext completeCallee: currentContext step.
					self changed: #pc.
					self updateInspectors]]