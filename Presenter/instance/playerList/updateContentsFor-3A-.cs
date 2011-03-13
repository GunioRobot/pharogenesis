updateContentsFor: aStatusViewer 
	"Rebuild the contents of the script-statusViewing tool"

	| showingOnlyActiveScripts candidateList firstTwo |

	showingOnlyActiveScripts _ aStatusViewer showingOnlyActiveScripts.
	self flushPlayerListCache.

	firstTwo  _ {aStatusViewer submorphs first.  aStatusViewer submorphs second}.
	aStatusViewer removeAllMorphs; addAllMorphs: firstTwo.
	
	candidateList _ self allExtantPlayers.
	aStatusViewer showingAllInstances "take all instances of all classes"
		ifTrue:
			[candidateList _ self allExtantPlayers]  

		ifFalse:  "include only one exemplar per uniclass.  Try to get one that has some qualifying scripts"
			[candidateList _ Set new.
			self allExtantPlayers do:
				[:aPlayer |
					(candidateList detect: [:plyr | plyr isMemberOf:  aPlayer class] ifNone: [nil]) ifNil:
						[aPlayer instantiatedUserScriptsDo: [:aScriptInstantiation |
							(showingOnlyActiveScripts not or: [#(paused ticking) includes: aScriptInstantiation status]) 								ifTrue:
									[candidateList add: aPlayer]]]]].
	candidateList do:
		[:aPlayer | aPlayer instantiatedUserScriptsDo:
			[:aScriptInstantiation |
				(showingOnlyActiveScripts not or: [#(paused ticking) includes: aScriptInstantiation status]) ifTrue:
					[aStatusViewer addMorphBack: (aScriptInstantiation statusControlRowIn: aStatusViewer)]]].