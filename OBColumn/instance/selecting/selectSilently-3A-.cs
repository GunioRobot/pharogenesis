selectSilently: aNode
	| match |
	aNode ifNil: [selection := 0. ^ self].
	match := children 
				detect: [:ea | ea correspondsWith: aNode] 
				ifNone: [selection := 0. ^ self].
	selection _ children indexOf: match.