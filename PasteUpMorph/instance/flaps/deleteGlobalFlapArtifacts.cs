deleteGlobalFlapArtifacts
	"self currentWorld deleteGlobalFlapArtifacts"

	| localFlaps |
	localFlaps _ self localFlapTabs collect: [:m | m referent].
	self submorphs do:
		[:m | 
			((m isKindOf: FlapTab) and: [m isGlobal]) ifTrue: [m delete].
			((m isKindOf: PasteUpMorph) and: [m hasProperty: #flap])
				ifTrue:
					[(localFlaps includes: m) ifFalse: [m delete]]]