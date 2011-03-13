changeTabText
	| reply |
	reply := UIManager default
		request: 'new wording for this tab:' translated
		initialAnswer: submorphs first contents.
	reply isEmptyOrNil ifFalse: [submorphs first contents: reply]