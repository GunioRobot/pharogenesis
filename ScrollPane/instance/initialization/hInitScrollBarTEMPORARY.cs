hInitScrollBarTEMPORARY
"This is called lazily before the hScrollBar is accessed in a couple of places. It is provided to transition old ScrollPanes lying around that do not have an hScrollBar. Once it has been in the image for awhile, and all ScrollPanes have an hScrollBar, this method and it's references can be removed. "

		"Temporary method for filein of changeset"
		hScrollBar ifNil: 
			[hScrollBar := ScrollBar new model: self slotName: 'hScrollBar'.
			hScrollBar borderWidth: 1; borderColor: Color black.
			self 
				resizeScrollBars;
				setScrollDeltas;
				hideOrShowScrollBars].
