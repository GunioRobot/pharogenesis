addToFormatter: formatter
	| href name |

	name _ self getAttribute: 'name'.
	name ifNotNil: [
		formatter noteAnchorStart: name ].

	href _ self getAttribute: 'href'.

	href isNil
		ifTrue: [ super addToFormatter: formatter ]
		ifFalse: [ 	
			formatter startLink: href.
			super addToFormatter: formatter.
			formatter endLink: href. ].
