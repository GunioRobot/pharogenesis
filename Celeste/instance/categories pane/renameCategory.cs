renameCategory
	"Rename the category with the user-specified name."

	| newCatName |
	mailDB ifNil: [ ^self ].
	self category ifNil: [ ^self ].

	newCatName _ FillInTheBlank
		request: 'New name?'
		initialAnswer: self category.
	(newCatName isEmpty) ifTrue: [^self].	"user aborted"
	mailDB renameCategory: self category to: newCatName.

	"currentCategory _ newCatName."   
	self changed: #categoryList.

	self setCategory: newCatName.
	self flag: #xxx.  "this is suboptimal for FilteringCeleste; the old category filter, if there is one, should be modified in place..."
