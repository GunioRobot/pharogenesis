loadSurfacePlugin
	"Load the surface support plugin"
	querySurfaceFn _ interpreterProxy ioLoadFunction:'ioGetSurfaceFormat' From:'SurfacePlugin'.
	lockSurfaceFn _ interpreterProxy ioLoadFunction:'ioLockSurface' From:'SurfacePlugin'.
	unlockSurfaceFn _ interpreterProxy ioLoadFunction:'ioUnlockSurface' From:'SurfacePlugin'.
	^querySurfaceFn ~= 0 and:[lockSurfaceFn ~= 0 and:[unlockSurfaceFn ~= 0]]