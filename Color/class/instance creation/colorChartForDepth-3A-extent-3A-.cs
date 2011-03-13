colorChartForDepth: depth extent: chartExtent
	"Displays a color palette using abstract colors.  fromUser can then save it.  Different for each depth.  6/26/96 tk
	Modified to produce a form of variable size instead of being
	fixed-size and running on the display 8/20/96 di"
	"(Color colorChartForDepth: Display depth extent: 720@100) display"
	| c p f nSteps rect w h |
	f _ Form extent: chartExtent depth: depth.
	nSteps _ depth>8 ifTrue: [12] ifFalse: [6].
	w _ chartExtent x // (nSteps*nSteps).
	h _ chartExtent y - 20 // nSteps.
	0 to: nSteps-1 do: [:r |
		0 to: nSteps-1 do: [:g |
			0 to: nSteps-1 do: [:b |
				c _ self red: r green: g blue: b range: nSteps-1.
				rect _ ((r*nSteps*w) + (b*w)) @ (g*h) extent: w@(h+1).
				f fill: rect fillColor: c].
			].
		].
	p _ chartExtent x // 3 @ (chartExtent y - 20).
	w _ chartExtent x - p x - 20 / 100.
	0 to: 99 do:
		[ :v | c _ self red: v green: v blue: v range: 99.
		f fill: ((v*w)@0 + p extent: (w+1)@20) fillColor: c].
	^ f