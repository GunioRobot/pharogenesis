getSelection
	"Sorry to feedle with fillInTheBlankMorph innards, but I had to"
	| text m |
	text := (MethodReference class: self getClass selector: self getSelector) sourceCode.
	m := FillInTheBlankMorph new.
	m setQuery: 'Highlight a part of the source code, and accept' initialAnswer: text
		answerExtent: 500@250
		acceptOnCR: true. 
	World addMorph: m centeredNear: World activeHand position.
	m getUserResponse.
	^ m selection