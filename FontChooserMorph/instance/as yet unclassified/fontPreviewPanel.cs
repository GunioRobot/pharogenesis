fontPreviewPanel 
	^fontPreviewPanel ifNil:
		[fontPreviewPanel := ScrollPane new
			color: Color white;
			borderInset;
			vResizing: #spaceFill;
			hResizing: #spaceFill.
		fontPreviewPanel scroller
			on: #mouseEnter send: #value: 
				to: [:event | event hand newKeyboardFocus: fontPreviewPanel scroller];
			on: #keyStroke send: #keyPressed: to: self.
		fontPreviewPanel.]