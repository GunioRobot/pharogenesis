connectRemoteUser
	"Prompt for the initials to be used to identify the cursor of a remote user, then create a cursor for that user and wait for a connection."

	| initials addr h |
	initials _ FillInTheBlank request: 'Enter initials for remote user''s cursor?'.
	initials isEmpty ifTrue: [^ self].  "abort"
	addr _ NetNameResolver promptUserForHostAddress.
	addr = 0 ifTrue: [^ self].  "abort"

	Socket ensureNetworkConnected.
	h _ RemoteHandMorph new userInitials: initials.
	self world addHand: h.
	h changed.
	h startListening.
	self startTransmittingEventsTo: addr.
