renderedMorph
	"If the receiver is a renderer morph, answer the rendered morph. Otherwise, answer the receiver. A renderer morph with no submorphs answers itself. See the comment in Morph>isRenderer."

	self isRenderer ifFalse: [^self].
	submorphs isEmpty ifTrue: [^self].
	^self firstSubmorph renderedMorph