categoryDefiningSelector: aSelector forClass: targetClass
	"Answer which category defines the selector for the given class.  Note reimplementor"

	| aClass |
	^ (aClass _ targetClass classThatUnderstands: aSelector) 
		ifNotNil:
			[aClass whichCategoryIncludesSelector: aSelector]