moduleUnloaded: aModuleName
	"The module with the given name was just unloaded.
	Make sure we have no dangling references."
	self export: true.
	self var: #aModuleName type: 'char *'.
	(aModuleName strcmp: 'SurfacePlugin') = 0 ifTrue:[
		"The surface plugin just shut down. How nasty."
		querySurfaceFn _ lockSurfaceFn _ unlockSurfaceFn _ 0.
	].