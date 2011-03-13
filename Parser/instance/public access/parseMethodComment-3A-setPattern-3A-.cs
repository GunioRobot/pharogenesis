parseMethodComment: aString setPattern: aBlock
	"Answer the method comment for the argument, aString. Evaluate aBlock 
	with the message pattern in the form #(selector, arguments, precedence)."

	self
		initPattern: aString
		notifying: nil
		return: aBlock.
	currentComment==nil
		ifTrue:	[^OrderedCollection new]
		ifFalse:	[^currentComment]