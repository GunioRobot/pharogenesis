mandatoryCategoriesFor: aClass
	"Return the categories that are mandatory for instances of <aClass>."

	^self categories select: [:c | c mandatoryFor: aClass]