internalFindNewMethod
	"Find the compiled method to be run when the current messageSelector is sent to the class 'lkupClass', setting the values of 'newMethod' and 'primitiveIndex'."
	| ok | 
	self inline: true.
	self sharedCodeNamed: 'commonLookup' inCase: 131.

	ok _ self lookupInMethodCacheSel: messageSelector class: lkupClass.
	ok ifFalse: [
		"entry was not found in the cache; look it up the hard way"
		self externalizeIPandSP.
		self lookupMethodInClass: lkupClass.
		self internalizeIPandSP.
		self addToMethodCacheSel: messageSelector
			class: lkupClass
			method: newMethod
			primIndex: primitiveIndex].
