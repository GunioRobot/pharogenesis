updateFrom6709
	"self new updateFrom6709"
	"PreferenceBrowser + Preference + Debugger fix + Services 
	+ SUnitGUI"
	
	self addRepositoryToPackageNamed: 'Services-Base'.
	self addRepositoryToPackageNamed: 'SUnitGUI'.
	self resetToolSet.
	self script23.
	self flushCaches.