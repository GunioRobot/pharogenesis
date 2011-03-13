proceed: aTopView 
	"Proceed from the interrupted state of the currently selected context. The 
	argument is the topView of the receiver. That view is closed."

	self okToChange ifFalse: [^ self].
	self checkContextSelection.
	contextStackIndex > 1 | externalInterrupt not 
		ifTrue: [self selectedContext push: proceedValue].
	self resumeProcess: aTopView