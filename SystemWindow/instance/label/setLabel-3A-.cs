setLabel: aString
	labelString _ aString.
	label ifNotNil: [label contents: aString]