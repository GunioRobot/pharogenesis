fastWindows
	StandardSystemView cachingBits
		ifTrue: [StandardSystemView dontCacheBits]
		ifFalse: [StandardSystemView doCacheBits]