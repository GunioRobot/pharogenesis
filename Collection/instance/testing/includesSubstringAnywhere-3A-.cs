includesSubstringAnywhere: testString
	"Answer whether the receiver includes, anywhere in its nested structure, a string that has testString as a substring"
	self do:
		[:element |
			(element isKindOf: String)
				ifTrue:
					[(element includesSubString: testString) ifTrue: [^ true]].
			(element isKindOf: Collection)
				ifTrue:
					[(element includesSubstringAnywhere: testString) ifTrue: [^ true]]].
	^ false

"#(first (second third) ((allSentMessages ('Elvis' includes:)))) includesSubstringAnywhere:  'lvi'"