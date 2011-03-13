actionsForParent: aNode
	| actions |
	actions _ self stdActionsForParent: aNode.
	aNode organization 
			isClassOrganizer ifTrue: [actions _ actions copyWith: (self categorizeActionFor: aNode)].
	^ actions