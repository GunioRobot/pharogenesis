allMorphs
	"Return a collection containing all morphs in this composite morph (including the receiver)."

	| all |
	all _ OrderedCollection new: 100.
	self allMorphsDo: [: m | all add: m].
	^ all