categoryWithNameIn: categoryNames thatIncludesSelector: aSelector forInstance: targetInstance ofClass: targetClass 
	"Answer the name of a category, from among the provided 
	categoryNames, which defines the selector for the given class. Here, if 
	the category designated by the implementing class is acceptable it is the 
	one returned"
	| aClass catName result |
	(aClass _ targetClass whichClassIncludesSelector: aSelector)
		ifNotNil: [(categoryNames includes: (catName _ aClass whichCategoryIncludesSelector: aSelector))
				ifTrue: [catName ~~ #'as yet unclassified'
						ifTrue: [^ catName]]].
	result _ super
				categoryWithNameIn: categoryNames
				thatIncludesSelector: aSelector
				forInstance: targetInstance
				ofClass: aClass.
	^ result
		ifNil: [#'as yet unclassified']