setupGStateForMorph: aMorph

	target comment: 'setupGState in EPSCanvas'.
	morphLevel == 1 ifTrue: [ 
		EPSCanvas bobsPostScriptHacks ifTrue: [	"needed to print RectangleMorph"
			self writeSetupForRect: aMorph bounds.
			target translate: aMorph bounds origin negated.
		] ifFalse: [
			target translate: aMorph bounds origin negated.
			self writeSetupForRect: aMorph bounds.
		].
	].
