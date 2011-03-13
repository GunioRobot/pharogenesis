ScrollController
	subclass: #ParagraphEditor
	instanceVariableNames:
		'paragraph startBlock stopBlock beginTypeInBlock emphasisHere initialText selectionShowing otherInterval lastParentLocation'
	classVariableNames:
		'ChangeText CmdActions FindText Keyboard ShiftCmdActions UndoInterval UndoMessage UndoParagraph UndoSelection Undone'
	poolDictionaries: 'TextConstants'
	category: 'Kernel-ST80 Remnants'