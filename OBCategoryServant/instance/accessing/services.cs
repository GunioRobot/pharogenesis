services
	| selectors |
	selectors _ self class organization listAtCategoryNamed: 'services'.
	^ selectors collect: [:ea | self perform: ea].
	