updateFrom7057
	"self new updateFrom7057"
	
	
	self script85.
	"fix windowColorRegistry"

	ServicePreferences wipe.
	ServiceRegistry rebuild.
	WindowColorRegistry refresh.
	self cleaningCS.
	
	self flushCaches.