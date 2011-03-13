expandedForm

	expandedForm ifNotNil: [ expandedForm depth ~= Display depth ifTrue: [ expandedForm := nil ]].

	^expandedForm ifNil: [expandedForm := 
			(Form
				extent: 10@9
				depth: 8
				fromArray: #( 4294967295 4294967295 4294901760 4294967295 4294967295 4294901760 4278255873 16843009 16842752 4294902089 1229539657 33488896 4294967041 1229539585 4294901760 4294967295 21561855 4294901760 4294967295 4278321151 4294901760 4294967295 4294967295 4294901760 4294967295 4294967295 4294901760)
				offset: 0@0)
					asFormOfDepth: Display depth;
					replaceColor: Color white withColor: Color transparent;
					yourself
	].
