translateBy: delta
	textSegments == nil ifTrue: [^ self].
	textSegments _ textSegments collect:
		[:ls | Array with: ((ls at: 1) translateBy: delta)
					with: ((ls at: 2) translateBy: delta)
					with: (ls at: 3)]