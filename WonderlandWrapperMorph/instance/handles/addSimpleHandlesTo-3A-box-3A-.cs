addSimpleHandlesTo: aHaloMorph box: aBox
	self flag: #noteToAndreas. 
		 "May want to reimplement this for wonderland morphs.  For the moment, this basically disallows simple handles in the wonderland case."
	^ aHaloMorph addCircleHandles