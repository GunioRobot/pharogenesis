browseMethodsWithString: aString
	"Launch a browser on all methods which contain string literals that have aString as a substring.  The search is case-sensitive, unless the option key is pressed, in which case the search is case-insensitive (and consequently somewhat slower)"

	| caseBlind testString suffix |
	(caseBlind _ Sensor optionKeyPressed)
		ifTrue:
			[testString _ aString asLowercase.
			suffix _ ' (case-blind)']
		ifFalse:
			[testString _ aString.
			suffix _ '-'].
	self browseAllSelect:
		[:method |  method  hasLiteralSuchThat:
				[:lit | lit class == String and:
					[lit includesSubstring: testString caseSensitive: caseBlind not]]]
				name:  'Methods with string ''', aString, '''', suffix
				autoSelect: aString