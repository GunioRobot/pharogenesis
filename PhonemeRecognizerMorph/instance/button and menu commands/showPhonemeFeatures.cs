showPhonemeFeatures
	"Show a graph of the features array for the phoneme selected by the user."

	| phoneme m |
	phoneme _ self selectPhonemeFromMenu: 'Show Features'.
	phoneme ifNotNil: [
		m _ ImageMorph new image: phoneme featuresGraph.
		self world firstHand attachMorph: m].
