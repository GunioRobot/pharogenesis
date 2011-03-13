getSelection
	"Sorry to feedle with fillInTheBlankMorph innards, but I had to"
	| text |
	text := (MethodReference class: self getClass selector: self getSelector) sourceCode.
	^ UIManager default 
			multiLineRequest: 'Clean out the source code and accept' translated
			centerAt: 0@0 
			initialAnswer: text
			answerHeight: 300.
