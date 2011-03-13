allMethodsInCategory: categoryName forInstance: anObject ofClass: aClass
	"Answer a list of all methods which are in the given category, on behalf of anObject"

	| classToUse |
	classToUse := aClass ifNil: [anObject class].
	^ classToUse allMethodsInCategory: categoryName