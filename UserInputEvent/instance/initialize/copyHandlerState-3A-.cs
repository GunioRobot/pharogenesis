copyHandlerState: anEvent
	"Copy the handler state from anEvent. Used for quickly transferring handler information between transformed events."
	handler _ anEvent handler.
	wasHandled _ anEvent wasHandled.