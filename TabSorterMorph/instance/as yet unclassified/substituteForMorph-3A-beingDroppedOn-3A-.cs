substituteForMorph: aMorph beingDroppedOn: aPage
	| aTab token |
	(aMorph isKindOf: PaintBoxMorph) ifTrue:
		[aTab _ ReferenceMorph new morphToInstall: aMorph.
		aTab removeAllMorphs.
		aTab addMorph: (SketchMorph withForm: (ScriptingSystem formAtKey: 'PaintTab')).
		aTab fitContents.
		token _ SorterTokenMorph new forMorph: aTab.
		^ token].
	(aMorph isKindOf: SorterTokenMorph) ifTrue: [^ nil].  "Let it stand"
	^ SorterTokenMorph new forMorph: (ReferenceMorph new morphToInstall: aMorph)