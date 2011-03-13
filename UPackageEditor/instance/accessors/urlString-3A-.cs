urlString: aString
	| url trimmedString |
	trimmedString := aString asString withBlanksTrimmed.
	url := (trimmedString isEmpty or: [ trimmedString beginsWith: '(' ])
		ifTrue: [ nil ]
		ifFalse: [ Url absoluteFromText: trimmedString ].
	package url: url.
	self changed: #urlString.
	^true