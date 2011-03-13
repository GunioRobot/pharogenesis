logToUser: aMessage
	"For now, we just show in the Smalltalk transcript, but when/if we have a permanent user control panel, we could divert such messages to that panel.  sw"
	self showInTranscript: aMessage.
	Transcript cr