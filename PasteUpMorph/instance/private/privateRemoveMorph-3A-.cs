privateRemoveMorph: aMorph
	backgroundMorph == aMorph ifTrue: [ backgroundMorph _ nil ].
	^super privateRemoveMorph: aMorph.
