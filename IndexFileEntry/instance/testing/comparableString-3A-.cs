comparableString: aString
	"This is for Celeste testing purposes only"

	"Return exactly this string.  This is the most strict mode, meaning things must be exactly equal"
	^ aString  

	"Make consecutive white space into a single space (less strict but still pretty)"
	"^ (aString collect: [ :ch | ch isSeparator ifTrue: [ Character space ] ifFalse: [ ch ] ])
			withBlanksCondensed"

	"Look only at nonwhite characters (least strict)"
	"^ aString select: [ :ch | ch isSeparator not ]"	



	"(self comparableString: 'a  b	c')  = (self comparableString: 'a	b     c')"
