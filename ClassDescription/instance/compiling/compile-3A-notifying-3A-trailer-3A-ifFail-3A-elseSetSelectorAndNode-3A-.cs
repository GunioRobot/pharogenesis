compile: code notifying: requestor trailer: bytes 
		ifFail: failBlock
		elseSetSelectorAndNode: selAndNodeBlock
	"Intercept this message in order to remember system changes.
	 5/15/96 sw: modified so that if the class does not wish its methods logged in the changes file, then they also won't be accumulated in the current change set.
	7/12/96 sw: use wantsChangeSetLogging to determine whether to put in change set"

	| methodNode selector newMethod priorMethodOrNil |
	methodNode _ self compilerClass new
				compile: code
				in: self
				notifying: requestor
				ifFail: failBlock.
	selector _ methodNode selector.
	selAndNodeBlock value: selector value: methodNode.
	requestor ifNotNil:
		["Note this change for recent submissions list"
		Utilities noteMethodSubmission: selector forClass: self].
	methodNode encoder requestor: requestor.  "Why was this not preserved?"
	newMethod _ methodNode generate: bytes.
	priorMethodOrNil _ (methodDict includesKey: selector)
		ifTrue: [self compiledMethodAt: selector]
		ifFalse: [nil].
	Smalltalk changes noteNewMethod: newMethod forClass: self
		selector: selector priorMethod: priorMethodOrNil.
	self addSelector: selector withMethod: newMethod.
	^ newMethod