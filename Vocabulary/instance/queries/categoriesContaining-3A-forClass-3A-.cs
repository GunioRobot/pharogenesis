categoriesContaining: aSelector forClass: aClass
	"Answer a list of categories that include aSelector"

	^ self categories select:
		[:aCategory | aCategory includesKey: aSelector]