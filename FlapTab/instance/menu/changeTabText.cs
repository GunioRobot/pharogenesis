changeTabText
	"Allow the user to change the text on the tab"

	| reply |
	reply _ FillInTheBlank
		request: 'new wording for this tab:' translated
		initialAnswer: self existingWording.
	reply isEmptyOrNil ifTrue: [^ self].
	self changeTabText: reply.
