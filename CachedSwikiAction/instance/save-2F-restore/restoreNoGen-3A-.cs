restoreNoGen: nameOfSwiki
	super restore: nameOfSwiki.
	self source: 'cswiki',(ServerAction pathSeparator).
	self cacheDirectory: (self class defaultCacheDirectory).
	self cacheURL: (self class defaultCacheURL).
	self pwsURL: (self class defaultPWSURL).
	"self generate."
