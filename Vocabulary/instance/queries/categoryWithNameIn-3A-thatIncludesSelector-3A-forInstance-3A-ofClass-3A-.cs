categoryWithNameIn: categoryNames thatIncludesSelector: aSelector forInstance: targetInstance ofClass: targetClass
	"Answer the name of a category, from among the provided categoryNames, which defines the selector for the given class.  Note reimplementor"

	| itsName |
	self categories do:
		[:aCategory | ((categoryNames includes: (itsName _ aCategory categoryName)) and:  [aCategory includesKey: aSelector])
			ifTrue:
				[^ itsName]].
	^ nil