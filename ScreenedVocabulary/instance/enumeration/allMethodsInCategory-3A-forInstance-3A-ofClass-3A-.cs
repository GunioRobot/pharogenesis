allMethodsInCategory: categoryName forInstance: anObject ofClass: aClass
	"Answer a list of all methods in the vocabulary which are in the given category, on behalf of the given class and object"

	^ (super allMethodsInCategory: categoryName forInstance: anObject ofClass: aClass) select:
		[:aSelector | self includesSelector: aSelector]