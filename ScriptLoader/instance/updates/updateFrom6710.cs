updateFrom6710
	"self new updateFrom6710"
	"Method annotations:
		Pay attention
	two important cs should be loaded after the cs that will trigger this update.
	one to recompile the image and to load the manually ordered CS."
	
	self addRepositoryToPackageNamed: 'Services-Base'.
	self addRepositoryToPackageNamed: 'SUnitGUI'.
	self resetToolSet.
	self script24.
	self flushCaches.