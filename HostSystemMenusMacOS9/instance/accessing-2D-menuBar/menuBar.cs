menuBar
	menuBar ifNil: 
			[menuBar := self primGetMenuBar].
	^menuBar