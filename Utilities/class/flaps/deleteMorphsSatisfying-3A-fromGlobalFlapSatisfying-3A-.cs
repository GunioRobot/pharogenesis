deleteMorphsSatisfying: deleteBlock fromGlobalFlapSatisfying: flapBlock
	"If any global flap satisfies flapBlock, Then delete objects satisfying from deleteBlock from it"

	| aFlapTab flapPasteUp |
	aFlapTab _ self globalFlapTabsIfAny detect: [:aTab | flapBlock value: aTab] ifNone: [^ self].
	flapPasteUp _ aFlapTab referent.
	flapPasteUp submorphs do:
		[:aMorph | (deleteBlock value: aMorph) ifTrue: [aMorph delete]]