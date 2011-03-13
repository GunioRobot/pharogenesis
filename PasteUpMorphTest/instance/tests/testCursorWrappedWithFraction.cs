testCursorWrappedWithFraction
	"self debug: #testCursorWrappedWithFraction"
	| holder |
	holder := PasteUpMorph new.
	holder addMorph: Morph new;
		 addMorph: Morph new;
		 addMorph: Morph new.
	holder cursorWrapped: 3.5.
	self assert: holder cursor = 3.5.
	holder cursorWrapped: 5.5.
	self assert: holder cursor = 2.5.
	holder cursorWrapped: 0.5.
	self assert: holder cursor = 3.5.
	holder cursorWrapped: -0.5.
	self assert: holder cursor = 2.5.