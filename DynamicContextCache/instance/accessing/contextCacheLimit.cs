contextCacheLimit
	"Answer the address of the first word after the last context cache frame."
	self inline: true.

	^contextCache + self contextCacheSize