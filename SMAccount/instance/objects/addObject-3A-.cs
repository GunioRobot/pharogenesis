addObject: anObject
	"Add <anObject> to this account. Also makes sure the
	reverse reference is correct."
	
	(objects includes: anObject) ifFalse:[
		objects add: anObject.
		anObject owner: self.
		map addObject: anObject]