likelyCategoryToShow
	"Choose a category to show based on what's already showing and on some predefined heuristics"

	| possible all aCat currVocab |
	all := (scriptedPlayer categoriesForViewer: self) asOrderedCollection.
	possible := all copy.
	currVocab := self currentVocabulary.
	self categoryMorphs do: 
			[:m | 
			aCat := currVocab categoryWhoseTranslatedWordingIs: m currentCategory.
			aCat ifNotNil: [possible remove: aCat wording ifAbsent: []]].
	(currVocab isEToyVocabulary) 
		ifTrue: 
			["hateful!"

			((possible includes: ScriptingSystem nameForInstanceVariablesCategory translated) 
				and: [scriptedPlayer hasUserDefinedSlots]) ifTrue: [^ ScriptingSystem nameForInstanceVariablesCategory].
			((possible includes: ScriptingSystem nameForScriptsCategory translated) and: [scriptedPlayer hasUserDefinedScripts]) 
				ifTrue: [^ ScriptingSystem nameForScriptsCategory]].
	{#basic translated} 
		do: [:preferred | (possible includes: preferred) ifTrue: [^preferred]].
	((scriptedPlayer isPlayerLike) 
		and: [scriptedPlayer hasOnlySketchCostumes]) 
			ifTrue: [(possible includes: #tests translated) ifTrue: [^#tests translated]].
	{#'color & border' translated. #tests translated. #color translated. #flagging translated. #comparing translated.} 
		do: [:preferred | (possible includes: preferred) ifTrue: [^preferred]].
	^possible isEmpty ifFalse: [possible first] ifTrue: [all first]