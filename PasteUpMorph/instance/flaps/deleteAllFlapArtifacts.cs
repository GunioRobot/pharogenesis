deleteAllFlapArtifacts
	"self currentWorld deleteAllFlapArtifacts"

	self submorphs do:
		[:m | (m hasProperty: #flap) ifTrue: [m delete].
			(m isKindOf: FlapTab) ifTrue: [ m delete]]