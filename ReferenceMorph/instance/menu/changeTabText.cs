changeTabText
	| reply |
	reply _ FillInTheBlankMorph request: 'new wording for this tab:' initialAnswer: submorphs first contents centerAt: Sensor cursorPoint inWorld: self world.
	reply isEmptyOrNil ifFalse:
		[submorphs first contents: reply]