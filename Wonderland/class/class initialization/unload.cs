unload

	FileList unregisterFileReader: self.
	(TheWorldMenu respondsTo: #registerOpenCommand:) ifTrue: 
		[TheWorldMenu unregisterOpenCommand: 'Wonderland 3D'].
