deleteGlobalFlapArtifacts
	"self currentWorld deleteGlobalFlapArtifacts"

	| localFlaps |
	localFlaps _ self localFlapTabs collect: [:m | m referent].
	self submorphs do:
		[:m | 
			((m isFlapTab) and: [m isGlobal]) ifTrue: [m delete].
			m isFlap ifTrue:[(localFlaps includes: m) ifFalse: [m delete]]]