doStep
	"Send the selected message in the accessed method, and regain control 
	after the invoked method returns."
	
	| currentContext newContext |
	self okToChange ifFalse: [^ self].
	self checkContextSelection.
	currentContext _ self selectedContext.
	newContext _ interruptedProcess completeStep: currentContext.
	newContext == currentContext ifTrue: [
		newContext _ interruptedProcess stepToSendOrReturn].
	self contextStackIndex > 1
		ifTrue: [self resetContext: newContext]
		ifFalse: [newContext == currentContext
				ifTrue: [self changed: #contentsSelection.
						self updateInspectors]
				ifFalse: [self resetContext: newContext]].
