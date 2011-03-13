noteThatFlag: prefSymbol justChangedTo: aBoolean
	"Provides a hook so that a user's toggling of a preference might precipitate some immediate action"
	| keep |
	prefSymbol == #useGlobalFlaps ifTrue:
		[aBoolean
			ifFalse:		"Turning off use of flaps"
				[keep _ self confirm:
'Do you want to preserve the existing
global flaps for future use?'.
				Utilities globalFlapTabsIfAny do:
					[:aFlapTab | Utilities removeFlapTab: aFlapTab keepInList: keep.
					aFlapTab isInWorld ifTrue: [self error: 'Flap problem']].
				keep ifFalse: [Utilities clobberFlapTabList]]

			ifTrue:		"Turning on use of flaps"
				[Smalltalk isMorphic ifTrue:
					[self currentWorld addGlobalFlaps]]].

	prefSymbol == #roundedWindowCorners ifTrue: [Display repaintMorphicDisplay].

	prefSymbol == #optionalButtons ifTrue:
		[Utilities replacePartSatisfying: [:el | (el isKindOf: MorphThumbnail) and: [(el morphRepresented isKindOf: SystemWindow) and: [el morphRepresented model isKindOf: FileList]]]
inGlobalFlapSatisfying: [:f1 | f1 wording = 'Tools'] with:  FileList openAsMorph applyModelExtent].

	(prefSymbol == #optionalButtons  or: [prefSymbol == #annotationPanes]) ifTrue:
		[Utilities replaceBrowserInToolsFlap].

	(prefSymbol == #smartUpdating) ifTrue:
		[SystemWindow allSubInstancesDo:
			[:aWindow | aWindow amendSteppingStatus]].

	(prefSymbol == #eToyFriendly) ifTrue:
		[ScriptingSystem customizeForEToyUsers: aBoolean].

	((prefSymbol == #infiniteUndo) and: [aBoolean not]) ifTrue:
		[CommandHistory resetCommandHistory]