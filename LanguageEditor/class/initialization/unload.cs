unload
	"the receiver is being unloaded"
	(TheWorldMenu respondsTo: #registerOpenCommand:)
		ifTrue: [""
			TheWorldMenu unregisterOpenCommand: 'Language Editor'.
			TheWorldMenu unregisterOpenCommand: 'Language Editor for...'] 