initializeEmbedded: aBool
	"aBool == true => inboard scrollbar
	aBool == false => flop-out scrollbar"
	self roundedScrollbarLook ifFalse:[^self].
	aBool ifTrue:[
		self borderStyle: (BorderStyle inset width: 2).
		self cornerStyle: #square.
	] ifFalse:[
		self borderStyle: (BorderStyle width: 1 color: Color black).
		self cornerStyle: #rounded.
	].
	self removeAllMorphs.
	self initializeSlider.