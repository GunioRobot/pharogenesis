allMorphsNotInPartsBins
	"Return a collection containing all morphs in this composite morph (including the receiver) other than those residing in a parts bin."

	| all |
	all _ OrderedCollection new: 100.
	self allMorphsNotInPartsBinsDo: [: m | all add: m].
	^ all