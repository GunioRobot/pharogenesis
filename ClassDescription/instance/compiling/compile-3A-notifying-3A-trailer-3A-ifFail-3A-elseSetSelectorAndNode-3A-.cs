compile: code notifying: requestor trailer: bytes
		ifFail: failBlock
		elseSetSelectorAndNode: selAndNodeBlock
	"Intercept this message in order to remember system changes.
	 5/15/96 sw: modified so that if the class does not wish its methods logged in the changes file, then they also won't be accumulated in the current change set.
	7/12/96 sw: use wantsChangeSetLogging to determine whether to put in change set"

	| methodNode selector method |
	methodNode _ self compilerClass new
				compile: code
				in: self
				notifying: requestor
				ifFail: failBlock.
	selector _ methodNode selector.
	selAndNodeBlock value: selector value: methodNode.
	self wantsChangeSetLogging ifTrue:
		[(methodDict includesKey: selector)
			ifTrue: [Smalltalk changes changeSelector: selector class: self]
			ifFalse: [Smalltalk changes addSelector: selector class: self]].
	methodNode encoder requestor: requestor.  "Why was this not preserved?"
	method _ methodNode generate: bytes.
	self addSelector: selector withMethod: method.
	^ method