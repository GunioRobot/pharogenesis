step
	| list fieldString msg |
	(list := super fieldList) = fieldList ifFalse:
		[fieldString := selectionIndex > 0 ifTrue: [fieldList at: selectionIndex] ifFalse: [nil].
		fieldList := list.
		selectionIndex := fieldList indexOf: fieldString ifAbsent: [0].
		self changed: #fieldList.
		self changed: #selectionIndex].
	list := msgList.  msgList := nil.  "force recomputation"
		list = self msgList ifFalse:
		[msg := msgListIndex > 0 ifTrue: [list at: msgListIndex] ifFalse: [nil].
		msgListIndex := msgList indexOf: msg ifAbsent: [0].
		self changed: #msgList.
		self changed: #msgListIndex].
	super step