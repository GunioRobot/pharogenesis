addToFormatter: formatter
	| src |
	src _ self getAttribute: 'src' default: nil.
	formatter ensureNewlines: 1.
	src ifNotNil: [ formatter startLink: src ].
	formatter addString: 'frame '.
	formatter addString: (self name ifNil: ['(unnamed)']).
	src ifNotNil:  [ formatter endLink: src ].
	formatter ensureNewlines: 1.