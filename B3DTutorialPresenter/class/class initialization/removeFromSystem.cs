removeFromSystem
	(TheWorldMenu respondsTo: #registerOpenCommand:) ifTrue: 
		[TheWorldMenu unregisterOpenCommand: 'Balloon3D Tutorial'].
	super removeFromSystem