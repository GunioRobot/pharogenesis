addCategory
	"Create a new category with the user-specified name. This does nothing if the category already exists."

	| newCatName |
	mailDB ifNil: [ ^self ].
	newCatName _ FillInTheBlank request: 'Name for new category?'.
	(newCatName isEmpty) ifTrue: [^self].	"user aborted"

	self requiredCategory: newCatName.
	self setCategory: newCatName.
