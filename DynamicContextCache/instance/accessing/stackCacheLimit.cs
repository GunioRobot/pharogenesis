stackCacheLimit
	"Answer the address of the first word after the last stack cache location."
	self inline: true.

	^stackCache + self stackCacheSize