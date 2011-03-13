firstPrecodeCommentFor:  selector
	"If there is a comment in the source code at the given selector that preceeds the body of the method, return it here, else return nil"

	| parser lastHeaderChar firstCommentPosition |
	"Behavior firstPrecodeCommentFor: #firstPrecodeCommentFor:"

	(parser _ self parserClass new) parseSelector: (self sourceCodeAt: selector).
	lastHeaderChar _ parser endOfLastToken.
	firstCommentPosition _ self positionOfFirstCommentAt: selector.
	^ (firstCommentPosition == nil or: [firstCommentPosition <= (lastHeaderChar + 4)])
		ifFalse:
			[nil]
		ifTrue:
			[self firstCommentAt: selector]