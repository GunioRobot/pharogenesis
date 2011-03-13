positionOfFirstCommentAt:  aSelector
	"Answer the position in the source string associated with aSelector of the first comment therein, or an empty string if none"

	| sourceString commentStart  |
	sourceString _ (self sourceCodeAt: aSelector) asString.
	sourceString size == 0 ifTrue: [^ 0].
	commentStart _ sourceString findString: '"' startingAt: 1.
	^ commentStart