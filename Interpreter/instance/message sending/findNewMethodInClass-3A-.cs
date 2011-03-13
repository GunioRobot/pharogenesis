findNewMethodInClass: class
	"Find the compiled method to be run when the current messageSelector is sent to the given class, setting the values of 'newMethod' and 'primitiveIndex'."
	| ok |
	self inline: false.
	ok _ self lookupInMethodCacheSel: messageSelector class: class.
	ok ifFalse: [
		"entry was not found in the cache; look it up the hard way"
		self lookupMethodInClass: class.
		lkupClass _ class.
		self addNewMethodToCache.
	].
