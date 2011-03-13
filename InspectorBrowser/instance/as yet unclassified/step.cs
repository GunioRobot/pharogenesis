step
	| list fieldString msg |
	(list _ super fieldList) = fieldList ifFalse:
		[fieldString _ selectionIndex > 0 ifTrue: [fieldList at: selectionIndex] ifFalse: [nil].
		fieldList _ list.
		selectionIndex _ fieldList indexOf: fieldString ifAbsent: [0].
		self changed: #fieldList.
		self changed: #selectionIndex].
	list _ msgList.  msgList _ nil.  "force recomputation"
		list = self msgList ifFalse:
		[msg _ msgListIndex > 0 ifTrue: [list at: msgListIndex] ifFalse: [nil].
		msgListIndex _ msgList indexOf: msg ifAbsent: [0].
		self changed: #msgList.
		self changed: #msgListIndex].
	super step