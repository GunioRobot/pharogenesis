firstCommentAt:  selector
	"Answer a string representing the first comment in the method associated with selector.  Return an empty string if the relevant source file is not available, or if the method's source code does not contain a comment.  Not smart enough to bypass quotes in string constants, but ""clever"" enough to map doubled quotes into a single quote.  5/1/96 sw"
	"Behavior firstCommentAt: #firstCommentAt:"

	| sourceString commentStart  pos nextQuotePos |

	sourceString _ self sourceCodeAt: selector.
	sourceString size == 0 ifTrue: [^ ''].
	commentStart _ sourceString findString: '"' startingAt: 1.
	commentStart == 0 ifTrue: [^ ''].
	pos _ commentStart + 1.
	[(nextQuotePos _ sourceString findString: '"' startingAt: pos) == (sourceString findString: '""' startingAt: pos)]
		whileTrue:
			[pos _ nextQuotePos + 2].
			
	^ (sourceString copyFrom: commentStart + 1 to: nextQuotePos - 1) copyReplaceAll: '""' with: '"'