zoomIn: goingIn orOutTo: otherImage at: topLeft vanishingPoint: vp
	"Display zoomInTo: (Form fromDisplay: (40@40 extent: 300@300)) reverse at: 40@40.
	Display zoomOutTo: (Form fromDisplay: (40@40 extent: 300@300)) reverse at: 40@40."
	| nSteps j bigR lilR |
	nSteps _ 16.
	^ self wipeImage: otherImage at: topLeft clippingBox: nil rectForIndex:
		[:i | "i runs from 1 to nsteps"
		i > nSteps ifTrue: [nil "indicates all done"]
			ifFalse:
			[j _ goingIn ifTrue: [i] ifFalse: [nSteps+1-i].
			bigR _ vp - (vp*(j)//nSteps) corner:
				vp + (otherImage extent-vp*(j)//nSteps).
			lilR _ vp - (vp*(j-1)//nSteps) corner:
				vp + (otherImage extent-vp*(j-1)//nSteps).
			bigR areasOutside: lilR]]