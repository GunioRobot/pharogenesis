addToFormatter: formatter
	| size color textAttribList |
	(formatter respondsTo: #startFont:)
		ifFalse: [^super addToFormatter: formatter].
	size _ self getAttribute: 'size'.
	color _ self getAttribute: 'color'.
	textAttribList _ OrderedCollection new.
	color ifNotNil: [textAttribList add: (TextColor color: (Color fromString: color))].
	(size isEmptyOrNil not and: [size isAllDigits]) 
		ifTrue: [size _ (size asNumber - 3) max: 1.
			textAttribList add: (TextFontChange fontNumber: (size min: 4))].
	formatter startFont: textAttribList.
	super addToFormatter: formatter.
	formatter endFont: textAttribList