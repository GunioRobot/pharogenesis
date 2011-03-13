restart: aTopView 
	"Proceed from the initial state of the currently selected context. The 
	argument is a controller on a view of the receiver. That view is closed."

	self okToChange ifFalse: [^ self].
	self checkContextSelection.
	(self selectedContext isKindOf: MethodContext)
		ifFalse:
			[(self confirm:
'I will have to revert to the method from
which this block originated.  Is that OK?')
				ifTrue: [self resetContext: self selectedContext home]
				ifFalse: [^self]].
	self selectedContext restart.
	self resumeProcess: aTopView