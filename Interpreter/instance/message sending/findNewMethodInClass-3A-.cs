findNewMethodInClass: class
	"Find the compiled method to be run when the current messageSelector is sent to the given class, setting the values of 'newMethod' and 'primitiveIndex'."

	| ok |
	self inline: true.
	ok _ self lookupInMethodCacheSel: messageSelector class: class.
	ok ifFalse: [
		"entry was not found in the cache; look it up the hard way"
		self lookupMethodInClass: class.
		primitiveIndex _ self primitiveIndexOf: newMethod.
		self addToMethodCacheSel: messageSelector
			class: class
			method: newMethod
			primIndex: primitiveIndex.
	].
