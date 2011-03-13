dontCacheBits
	"StandardSystemView dontCacheBits - Disable fast window repaint feature.
	Return true iff bits were cached, ie if space was been recovered"
	CacheBits ifFalse: [^ false].
	CacheBits := false.
	ScheduledControllers unCacheWindows.
	^ true