checkOverlap
	"DynamicInterpreter checkOverlap"

	| intSels coreSels |
	intSels _ DynamicInterpreter selectors.
	coreSels _ DynamicInterpreter selectors.
	Smalltalk
		browseMessageList: ((intSels select: [:sel | coreSels includes: sel])
								collect: [:sel | 'DynamicInterpreter ' , sel]) asSortedCollection
		name: 'overlapping methods'