renameCategory
	"Rename the category with the user-specified name."

	| newCatName |
	currentCategory ifNil: [ ^self ].

	newCatName _ FillInTheBlank
		request: 'New name?'
		initialAnswer: currentCategory.
	(newCatName isEmpty) ifTrue: [^self].	"user aborted"
	mailDB renameCategory: currentCategory to: newCatName.
	currentCategory _ newCatName.
	self changed: #categoryList.