aboutToBeGrabbedBy: aHand
	| editor |
	editor _ self topEditor.
	editor ifNotNil:[editor scriptEdited].
	^super aboutToBeGrabbedBy: aHand