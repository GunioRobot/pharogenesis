chooseCategory: aCategory
	"Choose the category of the given name, if there is one"

	self categoryListIndex: (categoryList indexOf: aCategory ifAbsent: [^ Beeper beep])