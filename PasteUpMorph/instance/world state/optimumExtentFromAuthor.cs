optimumExtentFromAuthor

	| opt |
	^self 
		valueOfProperty: #optimumExtentFromAuthor 
		ifAbsent: [
			opt _ bounds extent.
			self setProperty: #optimumExtentFromAuthor toValue: opt.
			^opt
		]

