addCoObject: anObject
	"Add <anObject> to this account.
	Only called from #addMaintainer:."
	
	(coObjects includes: anObject)
		ifFalse:[coObjects add: anObject]