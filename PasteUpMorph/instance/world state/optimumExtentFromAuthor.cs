optimumExtentFromAuthor

	| opt |
	^self 
		valueOfProperty: #optimumExtentFromAuthor 
		ifAbsent: [
			opt := bounds extent.
			self setProperty: #optimumExtentFromAuthor toValue: opt.
			^opt
		]

