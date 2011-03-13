setDefault
"
	self setDefault
"
	| tt |
	tt _ TTCFontDescription default.
	tt ifNil: [TTCFontDescription setDefault].
	tt _ TTCFontDescription default.
	tt ifNotNil: [self newTextStyleFromTT: tt].
