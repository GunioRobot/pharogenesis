disconnectRemoteUser
	"Prompt for the initials of the remote user, then remove the remote hand with those initials, breaking its connection."

	"select hand to remove"
	| initials handToRemove addr |
	initials _ FillInTheBlank request: 'Enter initials for remote user''s cursor?'.
	initials isEmpty ifTrue: [^ self].  "abort"
	handToRemove _ nil.
	self world hands do: [:h |
		h userInitials = initials ifTrue: [handToRemove _ h]].
	handToRemove ifNil: [^ self].  "no hand with those initials"

	addr _ handToRemove remoteHostAddress.
	addr = 0 ifFalse: [self stopTransmittingEventsTo: addr].
	handToRemove withdrawFromWorld.
