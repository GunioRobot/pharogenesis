showPageControls: controlSpecs 
	| spacer pageControls anIndex |
	self hidePageControls.
	anIndex _ (submorphs size > 0 and: [submorphs first hasProperty: #header])
		ifTrue:	[2]
		ifFalse:	[1].
	spacer _ Morph new color: color; extent: 0@10.
	spacer  setProperty: #pageControl toValue: true.
	self privateAddMorph: spacer atIndex: anIndex.

	pageControls _ self makePageControlsFrom: controlSpecs.
	pageControls borderWidth: 0; layoutInset: 4.
	pageControls  setProperty: #pageControl toValue: true.
	pageControls setNameTo: 'Page Controls'.
	pageControls eventHandler: (EventHandler new on: #mouseDown send: #move to: self).
	self privateAddMorph:  pageControls beSticky atIndex: anIndex