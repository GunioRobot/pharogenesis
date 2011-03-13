showPhonemeFeatures
	"Show a graph of the features array for the phoneme selected by the user."

	| phoneme m |
	phoneme := self selectPhonemeFromMenu: 'Show Features'.
	phoneme ifNotNil: [
		m := ImageMorph new image: phoneme featuresGraph.
		self world firstHand attachMorph: m].
