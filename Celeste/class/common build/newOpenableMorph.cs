newOpenableMorph
	"Answer window for a MailReader on a blank database."

	self == Celeste ifTrue: [
		^self interfaceClass newOpenableMorph ].

	^ (self buildTopMorphicWindowTitled: self defaultWindowTitle model: (self onDatabase: nil)) applyModelExtent