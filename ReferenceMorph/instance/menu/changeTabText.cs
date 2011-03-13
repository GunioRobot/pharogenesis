changeTabText
	| reply |
	reply _ FillInTheBlank
		request: 'new wording for this tab:'
		initialAnswer: submorphs first contents.
	reply isEmptyOrNil ifFalse: [submorphs first contents: reply]