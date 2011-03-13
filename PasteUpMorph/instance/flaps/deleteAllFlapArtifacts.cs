deleteAllFlapArtifacts
	"self currentWorld deleteAllFlapArtifacts"

	self submorphs do:[:m | m isFlapOrTab ifTrue:[m delete]]