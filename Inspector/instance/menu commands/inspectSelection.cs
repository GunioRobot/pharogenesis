inspectSelection
	"Create and schedule an Inspector on the receiver's model's currently 
	selected object."

	self selectionIndex = 0 ifTrue: [^ self changed: #flash].
	^ self selection smartInspect  "eliminate annoyance of 1-element collections"