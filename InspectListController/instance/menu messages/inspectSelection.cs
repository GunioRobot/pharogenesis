inspectSelection
	"Create and schedule an Inspector on the receiver's model's currently 
	selected object."

	model selectionIndex = 0
		ifTrue: [^view flash].
	self controlTerminate.
	^model selection smartInspect  "eliminate annoyance of 1-element collections"