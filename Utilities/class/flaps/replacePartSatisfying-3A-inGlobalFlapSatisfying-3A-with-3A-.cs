replacePartSatisfying: elementBlock inGlobalFlapSatisfying: flapBlock with: replacement
	"If any global flap satisfies flapBlock, look in it for a part satisfying elementBlock; if such a part is found, replace it with the replacement morph, make sure the flap's layout is made right, etc."

	| aFlapTab flapPasteUp anElement |
	aFlapTab _ self globalFlapTabsIfAny detect: [:aTab | flapBlock value: aTab] ifNone: [^ self].
	flapPasteUp _ aFlapTab referent.
	anElement _ flapPasteUp submorphs detect: [:aMorph | elementBlock value: aMorph] ifNone: [^ self].
	flapPasteUp replaceSubmorph: anElement by: replacement.
	flapPasteUp replaceTallSubmorphsByThumbnails; setPartsBinStatusTo: true.

"Utilities replacePartSatisfying: [:el |  (el isKindOf: MorphThumbnail) and: [(el morphRepresented isKindOf: SystemWindow) and: [el morphRepresented label = 'scripting area']]]
inGlobalFlapSatisfying: [:fl | (fl submorphs size > 0) and:  [(fl submorphs first isKindOf: TextMorph) and: [(fl submorphs first contents string copyWithout: Character cr) = 'Tools']]] with: ScriptingSystem newScriptingSpace"