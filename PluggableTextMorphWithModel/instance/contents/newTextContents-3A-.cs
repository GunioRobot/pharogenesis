newTextContents: stringOrText
	"Accept new text contents."

	| newText aStack setter myText |
	"Just underway; trying to make this work like TextMorph does, but not quite there yet."

	newText _ stringOrText asText.
	(myText _ textMorph text) = newText ifTrue: [^ self].  "No substantive change"

	(self holdsSeparateDataForEachInstance and: [(aStack _ self stack) notNil])
		ifTrue:
			[setter _ self valueOfProperty: #setterSelector.
			setter ifNotNil:
				[(self valueOfProperty: #cardInstance) perform: setter with: newText]].

	self world ifNotNil:
		[self world startSteppingSubmorphsOf: self ].
