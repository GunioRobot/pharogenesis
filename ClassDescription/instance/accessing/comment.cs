comment
	"Answer the receiver's comment. (If old format, not a Text, unpack the old way.) "

	| aString |
	aString _ self theNonMetaClass organization classComment.
	(aString asString beginsWith: self name, ' comment:\''' withCRs) 
		ifFalse: [^ self theNonMetaClass organization classComment]
		ifTrue: ["old format"
			aString size = 0 ifTrue: [^''].
			"get string only of classComment, undoubling quotes"
			^ String readFromString: aString]