removeObject: anObject
	"Remove <anObject> from this category. This should only be called
	from SMCategorizableObject>>removeCategory: to ensure consistency."
	
	^objects remove: anObject