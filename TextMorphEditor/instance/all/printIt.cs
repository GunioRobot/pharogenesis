printIt
	"Treat the current text selection as an expression; evaluate it. Insert the 
	description of the result of evaluation after the selection and then make 
	this description the new text selection."

	| result aString |
	result _ self doIt.
	result ~~ #failedDoit
		ifTrue: [
			aString _ result printString.
			self replace: (stopBlock stringIndex to: stopBlock stringIndex - 1) 
				with: (' ' , aString) asText and: [self selectAndScroll] ]