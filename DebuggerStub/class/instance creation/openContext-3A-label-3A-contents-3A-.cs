openContext: haltContext label: labelString contents: contentsString
	| stub |
	World addMorph: (stub _ (self labelled: labelString) setStackText: contentsString).
	stub changed