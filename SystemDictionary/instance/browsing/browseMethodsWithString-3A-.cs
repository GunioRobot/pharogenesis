browseMethodsWithString: aString
	"Launch a browser on all methods that contain string literals with aString as a substring. The search is case-insensitive, unless the shift key is pressed, in which case the search is case-sensitive."

	| caseSensitive suffix |
	(caseSensitive _ Sensor shiftPressed)
		ifTrue: [suffix _ ' (case-sensitive)']
		ifFalse: [suffix _ ' (use shift for case-sensitive)'].
	self browseAllSelect:
			[:method |
				method  hasLiteralSuchThat: [:lit |
					lit class == String and:
					[lit includesSubstring: aString caseSensitive: caseSensitive]]]
		name:  'Methods with string ', aString printString, suffix
		autoSelect: aString.
