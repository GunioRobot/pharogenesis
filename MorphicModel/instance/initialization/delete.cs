delete

	(model isKindOf: MorphicModel) ifFalse: [^ super delete].

	(PopUpMenu confirm:
'Shall I remove the slot ', slotName, '
along with all associated methods?') ifTrue: [
		(model class selectors select: [:s | s beginsWith: slotName])
			do: [:s | model class removeSelector: s].
		(model class instVarNames includes: slotName)
			ifTrue: [model class removeInstVarName: slotName].
	] ifFalse: [
		(PopUpMenu confirm:
'...but should I at least dismiss this morph?
[choose no to leave everything unchanged]')
			ifFalse: [^ self]].

	super delete.
