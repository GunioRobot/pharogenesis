usePatch: aPatch

	| aTile displayer |
	self removeAllMorphs.
	literal _ aPatch.


	aTile _ KedamaPatchType basicNew newReadoutTile.

	displayer _ UpdatingStringMorph new
		getSelector: #externalName;
		target: aPatch;
		growable: true;
		minimumWidth: 24;
		putSelector: nil.
	displayer stepTime: 1000.
	"Note that when typeSymbol = #number, the #target: call above will have dealt with floatPrecision details"

	displayer useStringFormat.
	aTile addMorphBack: displayer.
	aTile setLiteralInitially: (aPatch perform: #externalName).
	self addMorphBack: aTile.
