filterToUncommentedMethods
	"Filter the receiver's list down to only those items which lack comments"

	self filterFrom:
		[:aClass :aSelector |
			(aClass selectors includes: aSelector) and:
						[(aClass firstPrecodeCommentFor: aSelector) isEmptyOrNil]]