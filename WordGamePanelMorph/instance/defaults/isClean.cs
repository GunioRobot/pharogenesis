isClean
	"Return true only if all cells are blank."

	letterMorphs do:
		[:m | (m letter notNil and: [m letter ~= $ ]) ifTrue: [^ false]].
	^ true
