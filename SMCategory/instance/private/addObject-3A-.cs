addObject: anObject
	"Add <anObject> to this category. This should only be called
	from SMCategorizableObject>>addCategory: to ensure consistency."
	
	(objects includes: anObject) ifFalse:[objects add: anObject]