acceptDroppingMorph: aMorph event: evt

	(aMorph isKindOf: NewHandleMorph) ifTrue: [^self].
	(aMorph isKindOf: GeeBookMorph) ifTrue: [^self].	"avoid looping"
	self addMorph: aMorph.
	aMorph allMorphsDo: [ :each | theTextMorph removeAlansAnchorFor: each].
	theTextMorph linkNewlyDroppedMorph: aMorph