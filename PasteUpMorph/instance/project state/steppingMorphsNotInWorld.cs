steppingMorphsNotInWorld
	| all |
	all _ self allMorphs.
	^ self listOfSteppingMorphs select: [:m | (all includes: m) not]

	"self currentWorld steppingMorphsNotInWorld do: [:m | m delete]"