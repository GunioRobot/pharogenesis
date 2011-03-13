assureTaskbarPresenceMatchesPreference
	"Synchronize the state of the receiver's taskbar with the preference."
	
	(self showWorldTaskbar)
		ifTrue: [self createTaskbarIfNecessary]
		ifFalse: [self removeTaskbar]