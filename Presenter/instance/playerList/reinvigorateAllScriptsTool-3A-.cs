reinvigorateAllScriptsTool: anAllScriptsTool 
	"Rebuild the contents of an All Scripts tool"

	| showingOnlyActiveScripts candidateList firstTwo oldList allExtantPlayers newList morphList |
	showingOnlyActiveScripts _ anAllScriptsTool showingOnlyActiveScripts.
	self flushPlayerListCache.
	"needed? Probably to pick up on programmatical script-status control only"

	firstTwo _ {anAllScriptsTool submorphs first.  anAllScriptsTool submorphs second}.
	oldList _ (anAllScriptsTool submorphs copyFrom: 3 to: anAllScriptsTool submorphs size) collect:
		[:aRow |
			(aRow findA: UpdatingSimpleButtonMorph) target].

	allExtantPlayers _ self allExtantPlayers.
	anAllScriptsTool showingAllInstances "take all instances of all classes"
		ifTrue:
			[candidateList _ allExtantPlayers]  

		ifFalse:  "include only one exemplar per uniclass.  Try to get one that has some qualifying scripts"
			[candidateList _ Set new.
			allExtantPlayers do:
				[:aPlayer |
					(candidateList detect: [:plyr | plyr isMemberOf:  aPlayer class] ifNone: [nil]) ifNil:
						[aPlayer instantiatedUserScriptsDo: [:aScriptInstantiation |
							(showingOnlyActiveScripts not or: [aScriptInstantiation pausedOrTicking]) 								ifTrue:
									[candidateList add: aPlayer]]]]].
	newList _ OrderedCollection new.
	candidateList do:
		[:aPlayer | aPlayer instantiatedUserScriptsDo:
			[:aScriptInstantiation |
				(showingOnlyActiveScripts not or: [aScriptInstantiation pausedOrTicking]) ifTrue:
					[newList add: aScriptInstantiation]]].

	oldList asSet = newList asSet
		ifFalse:
			[anAllScriptsTool removeAllMorphs; addAllMorphs: firstTwo.
			morphList _ newList collect:
				[:aScriptInstantiation |  aScriptInstantiation statusControlRowIn: anAllScriptsTool].
			anAllScriptsTool addAllMorphs: morphList.
			newList do:
				[:aScriptInstantiation | aScriptInstantiation updateAllStatusMorphs]]