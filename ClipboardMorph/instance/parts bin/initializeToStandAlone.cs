initializeToStandAlone
	super initializeToStandAlone.
""
	self initialize.
	""
	self extent: 200 @ 100.
	self
		backgroundColor: (Color
				r: 0.484
				g: 1.0
				b: 0.484).
	self setBalloonText: 'This shows the current contents of the text clipboard'.
	self newContents: Clipboard clipboardText