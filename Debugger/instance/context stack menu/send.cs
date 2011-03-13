send
	"Send the selected message in the accessed method, and take control in 
	the method invoked to allow further step or 
send."

	| currentContext |
	"Sensor leftShiftDown ifTrue: [self halt]."
	self okToChange ifFalse: [^ self].
	self checkContextSelection.
	externalInterrupt ifFalse: [contextStackTop push: proceedValue].
	externalInterrupt _ true. "simulation leaves same state as interrupting"
	currentContext _ self selectedContext.
	currentContext stepToSendOrReturn.
	self contextStackIndex > 1 | currentContext willReturn
		ifTrue: 
			[self changed: #notChanged]
		ifFalse: 
			[currentContext _ currentContext step.
			currentContext stepToSendOrReturn.
			self resetContext: currentContext]