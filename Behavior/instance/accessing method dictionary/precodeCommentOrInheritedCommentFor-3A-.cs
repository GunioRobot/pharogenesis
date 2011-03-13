precodeCommentOrInheritedCommentFor:  selector
	"Answer a string representing the first comment in the method associated with selector, considering however only comments that occur before the beginning of the actual code.  If the version recorded in the receiver is uncommented, look up the inheritance chain.  Return an empty string if none found.  Not smart enough to bypass quotes in string constants, but does map doubled quote into a single quote."

	| aSuper aComment |
	^ (aComment _ self firstPrecodeCommentFor: selector) isEmptyOrNil
		ifFalse:
			[aComment]
		ifTrue:
			[(self == Behavior or: [superclass == nil or:
							[(aSuper _ superclass classThatUnderstands: selector) == nil]])
				ifTrue:
					['']
				ifFalse:
					[aSuper precodeCommentOrInheritedCommentFor: selector]]

"Utilities class precodeCommentOrInheritedCommentFor: #testingComment"