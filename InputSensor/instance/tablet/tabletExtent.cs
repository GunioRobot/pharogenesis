tabletExtent
	"Answer the full tablet extent in tablet coordinates."

	| params |
	params _ self primTabletGetParameters: 1.
	params ifNil: [^ self error: 'no tablet available'].
	^ (params at: 1)@(params at: 2)
