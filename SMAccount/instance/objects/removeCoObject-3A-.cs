removeCoObject: anObject
	"Remove <anObject> from this account.
	Only called from #removeMaintainer:."

	(coObjects includes: anObject) ifTrue: [
		coObjects remove: anObject]