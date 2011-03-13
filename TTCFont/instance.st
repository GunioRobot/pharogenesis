AbstractFont
	subclass: #TTCFont
	instanceVariableNames:
		'ttcDescription pointSize foregroundColor cache derivatives fallbackFont height ascent descent maxAscii colorToCacheMap'
	classVariableNames:
		'GlyphCacheData GlyphCacheIndex GlyphCacheReady GlyphCacheSize NamesToIndexes Registry Scale ShutdownList'
	poolDictionaries: ''
	category: 'Multilingual-Display'