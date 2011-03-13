scanCategory  "or other preamble"
	| itemPosition item tokens |
	itemPosition _ file position.
	item _ file nextChunk.
	tokens _ Scanner new scanTokens: item.
	(tokens size >= 3 and: [(tokens at: 2) = #methodsFor:])
		ifTrue: [self scanCategory: (tokens at: 3) class: (tokens at: 1) meta: false]
		ifFalse: [(tokens size >= 4 and: [(tokens at: 3) = #methodsFor:])
			ifTrue: [self scanCategory: (tokens at: 4) class: (tokens at: 1) meta: true]
			ifFalse: [self addItem: (ChangeRecord new file: file position: itemPosition type: #preamble) text: ('preamble: ' , item contractTo: 50)]]