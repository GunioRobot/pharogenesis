okToStyle
	styler ifNil:[^false].
	Preferences syntaxHighlightingAsYouType ifFalse: [^false].
	(model respondsTo: #shoutAboutToStyle: ) ifFalse:[^true].
	^model shoutAboutToStyle: self
