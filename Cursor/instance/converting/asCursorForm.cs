asCursorForm
	| form |
	form _ Form extent: self extent depth: 8.
	form fillShape: self fillColor: Color black at: offset negated.
	^ form offset: offset