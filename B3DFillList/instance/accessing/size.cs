size
	| n face |
	n _ 0.
	face _ firstFace.
	[face == nil] whileFalse:[
		n _ n + 1.
		face _ face nextFace.
	].
	^n