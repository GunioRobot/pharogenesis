findMultiSubstring: key in: body startingAt: start matchTable: matchTable
	"Answer the index in the string body at which the substring key first occurs, at or beyond start.  The match is determined using matchTable, which can be used to effect, eg, case-insensitive matches.  If no match is found, zero will be returned.

	The algorithm below is not optimum -- it is intended to be translated to C which will go so fast that it wont matter."
	| index c1 c2 |
	self var: #key declareC: 'unsigned int *key'.
	self var: #body declareC: 'unsigned int *body'.
	self var: #matchTable declareC: 'unsigned char *matchTable'.
	self var: #c1 declareC: 'unsigned int c1'.
	self var: #c2 declareC: 'unsigned int c2'.

	matchTable == nil ifTrue: [
		key size = 0 ifTrue: [^ 0].
		start to: body size - key size + 1 do:
			[:startIndex |
			index _ 1.
				[(body at: startIndex+index-1)
					= (key at: index)]
					whileTrue:
					[index = key size ifTrue: [^ startIndex].
					index _ index+1]].
		^ 0
	].

	key size = 0 ifTrue: [^ 0].
	start to: body size - key size + 1 do:
		[:startIndex |
		index _ 1.
		[c1 _ body at: startIndex+index-1.
		c2 _ key at: index.
		((c1 leadingChar = 0) ifTrue: [(matchTable at: c1 asciiValue + 1)]
						ifFalse: [c1 asciiValue + 1])
			= ((c2 leadingChar = 0) ifTrue: [(matchTable at: c2 asciiValue + 1)]
								ifFalse: [c2 asciiValue + 1])]
			whileTrue:
				[index = key size ifTrue: [^ startIndex].
				index _ index+1]].
	^ 0
