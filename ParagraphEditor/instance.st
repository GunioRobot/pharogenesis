ScrollController
	subclass: #ParagraphEditor
	instanceVariableNames:
		'paragraph startBlock stopBlock beginTypeInBlock emphasisHere initialText selectionShowing otherInterval '
	classVariableNames:
		'UndoInterval UndoSelection CurrentSelection Keyboard TextEditorYellowButtonMenu TextEditorYellowButtonMessages CmdActions UndoParagraph Undone UndoMessage ShiftCmdActions FindText ChangeText '
	poolDictionaries: 'TextConstants '
	category: 'Graphics-Editors'