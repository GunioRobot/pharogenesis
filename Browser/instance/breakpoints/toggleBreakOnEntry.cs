toggleBreakOnEntry
	"Install or uninstall a halt-on-entry breakpoint"
	super toggleBreakOnEntry.
	self changed: #messageList
		