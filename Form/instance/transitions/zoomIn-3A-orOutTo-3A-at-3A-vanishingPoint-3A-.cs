zoomIn: goingIn orOutTo: otherImage at: topLeft vanishingPoint: vp 
	"Display zoomInTo: (Form fromDisplay: (40@40 extent: 300@300)) reverse at: 40@40.
	Display zoomOutTo: (Form fromDisplay: (40@40 extent: 300@300)) reverse at: 40@40."
	| nSteps j bigR lilR minTime startTime lead |
	nSteps _ 16.
	minTime _ 500.  "milliseconds"
	startTime _ Time millisecondClockValue.
	^ self wipeImage: otherImage at: topLeft clippingBox: nil rectForIndex:
		[:i | "i runs from 1 to nsteps"
		i > nSteps
			ifTrue: [nil "indicates all done"]
			ifFalse:
			["If we are going too fast, delay for a bit"
			lead _ startTime + (i-1*minTime//nSteps) - Time millisecondClockValue.
			lead > 10 ifTrue: [(Delay forMilliseconds: lead) wait].

			"Return an array with the difference rectangles for this step."
			j _ goingIn ifTrue: [i] ifFalse: [nSteps+1-i].
			bigR _ vp - (vp*(j)//nSteps) corner:
				vp + (otherImage extent-vp*(j)//nSteps).
			lilR _ vp - (vp*(j-1)//nSteps) corner:
				vp + (otherImage extent-vp*(j-1)//nSteps).
			bigR areasOutside: lilR]]