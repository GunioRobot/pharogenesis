genericTextFieldNamed: aString

	| newField |

	newField _ TextMorph new
		beAllFont: self myFont;
		extent: 300@20;
		contentsWrapped: ''.
	namedFields at: aString put: newField.
	^newField
