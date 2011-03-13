testCursorWrapped
	"self debug: #testCursorWrapped"
	| holder |
	holder := PasteUpMorph new.
	self assert: holder cursor = 1.
	holder cursorWrapped: 2.
	self assert: holder cursor = 1.
	holder addMorph: Morph new;
		 addMorph: Morph new;
		 addMorph: Morph new.
	holder cursorWrapped: 3.
	self assert: holder cursor = 3.
	holder cursorWrapped: 5.
	self assert: holder cursor = 2.
	holder cursorWrapped: 0.
	self assert: holder cursor = 3.
	holder cursorWrapped: -1.
	self assert: holder cursor = 2.