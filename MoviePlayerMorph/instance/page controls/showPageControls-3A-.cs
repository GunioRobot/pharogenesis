showPageControls: controlSpecs 
	| pageControls |
	self hidePageControls.

	pageControls := self makePageControlsFrom: controlSpecs.
	pageControls borderWidth: 0; layoutInset: 0; extent: pageControls width@14.
	pageControls  setProperty: #pageControl toValue: true.
	pageControls setNameTo: 'Page Controls'.
	pageControls eventHandler: (EventHandler new on: #mouseDown send: #move to: self).
	self addMorphBack: pageControls beSticky