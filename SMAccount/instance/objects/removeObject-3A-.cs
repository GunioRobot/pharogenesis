removeObject: anObject
	"Remove <anObject> from this account. Also makes sure the
	reverse reference is cleared."

	(objects includes: anObject) ifTrue: [
		anObject owner: nil.
		objects remove: anObject]