justGrabbedFrom: formerOwner
	| editor |
	formerOwner ifNil:[^self].
	editor _ formerOwner topEditor.
	editor ifNotNil:[editor scriptEdited].