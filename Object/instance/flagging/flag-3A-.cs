flag: aSymbol
	"Send this message, with a relevant symbol as argument, to flag a message for subsequent retrieval.  For example, you might put the following line in a number of messages:
	self flag: #returnHereUrgently
	Then, to retrieve all such messages, browse all senders of #returnHereUrgently."

	"flags in use currently:
		hot (used by sw to flag methods he must revisit; things hotter than hot are flagged #hottest)
		developmentNote
		scottPrivate
		toBeRemoved
		noteToDan
		noteToJohn
		noteToTed"