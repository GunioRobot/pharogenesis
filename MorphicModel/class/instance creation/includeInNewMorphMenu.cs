includeInNewMorphMenu
	"Only include Models that have been saved"
	self == MorphicModel ifTrue: [^ false].
	^ self includesSelector: #initMorph