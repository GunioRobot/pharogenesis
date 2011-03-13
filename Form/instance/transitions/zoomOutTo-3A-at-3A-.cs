zoomOutTo: otherImage at: topLeft
	"Display zoomOutTo: (Form fromDisplay: (40@40 extent: 300@300)) reverse at: 40@40"
	^ self wipeImage: otherImage at: topLeft rectForIndex:
		[:i | i <= 16
			ifTrue: [(otherImage center - (otherImage extent*(17-i)//32)
						extent: otherImage extent*(17-i)//16)
					areasOutside:
					(otherImage center - (otherImage extent*(16-i)//32)
						extent: otherImage extent*(16-i)//16)]
			ifFalse: [nil]]