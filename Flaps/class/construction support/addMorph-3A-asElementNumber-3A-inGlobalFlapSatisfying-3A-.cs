addMorph: aMorph asElementNumber: aNumber inGlobalFlapSatisfying: flapBlock
	"If any global flap satisfies flapBlock, add aMorph to it at the given position.  Applies to flaps that are parts bins and that like thumbnailing"

	| aFlapTab flapPasteUp |
	aFlapTab _ self globalFlapTabsIfAny detect: [:aTab | flapBlock value: aTab] ifNone: [^ self].
	flapPasteUp _ aFlapTab referent.
	flapPasteUp addMorph: aMorph asElementNumber: aNumber.
	flapPasteUp replaceTallSubmorphsByThumbnails; setPartsBinStatusTo: true