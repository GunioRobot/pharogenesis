longAt: index bigEndian: aBool
	"Return a 32bit integer quantity starting from the given byte index"
	| b0 b1 b2 w h |
	aBool ifTrue:[
		b0 _ self at: index.
		b1 _ self at: index+1.
		b2 _ self at: index+2.
		w _ self at: index+3.
	] ifFalse:[
		w _ self at: index.
		b2 _ self at: index+1.
		b1 _ self at: index+2.
		b0 _ self at: index+3.
	].
	"Minimize LargeInteger arithmetic"
	h _ ((b0 bitAnd: 16r7F) - (b0 bitAnd: 16r80) bitShift: 8) + b1.
	b2 = 0 ifFalse:[w _ (b2 bitShift: 8) + w].
	h = 0 ifFalse:[w _ (h bitShift: 16) + w].
	^w