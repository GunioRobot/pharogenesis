allSelectors
	| selectors |
	selectors _ self subject allSelectors.
	self exclusions do: [:each |
		selectors remove: each ifAbsent: []].
	^selectors