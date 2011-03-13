nameOfCategoryContaining: aSelector
	"Answer a category that include aSelector, or nil if none"

	^ (self categories detect:
		[:aCategory | aCategory includesKey: aSelector] ifNone: [^ nil]) categoryName