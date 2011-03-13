zoomInTo: otherImage at: topLeft
	"Display zoomInTo: (Form fromDisplay: (40@40 extent: 300@300)) reverse at: 40@40"
	^ self wipeImage: otherImage at: topLeft rectForIndex:
		[:i | i <= 16
			ifTrue: [otherImage center - (otherImage extent*i//32)
						extent: otherImage extent*i//16]
			ifFalse: [nil]]