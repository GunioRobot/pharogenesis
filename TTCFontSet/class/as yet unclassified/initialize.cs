initialize
"
	self initialize
"

	| tt |
	tt _ TTCFontDescription default.
	tt ifNotNil: [self newTextStyleFromTT: tt].
