startOrFinishDrawing: evt
	| w |
	self flapShowing ifTrue:[
		(w _ self world) makeNewDrawing: evt at:  w center.
	] ifFalse:[
		self world endDrawing: evt.
	].