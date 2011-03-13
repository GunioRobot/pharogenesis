someHalo
	"Return some halo that's currently visible in the world"
	| m |
	^ (m _ self haloMorphs) size > 0 ifTrue: [m first] ifFalse: [nil]