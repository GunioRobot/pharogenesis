findNewMethodInClass: class
	"Find the compiled method to be run when the current messageSelector is sent to the given class, setting the values of 'newMethod' and 'primitiveIndex'."

	| ok cls sel |
	self inline: true.
	sel _ messageSelector.
	ok _ self lookupInMethodCacheSel: sel class: class.
	ok ifFalse: [
		statMethodCacheMisses _ statMethodCacheMisses + 1.
		"entry was not found in the cache; look it up the hard way"
		self pushRemappableOop: class.
		self lookupMethodInClass: class.		"Can provoke GC if createActualMessage is called"
		cls _ self popRemappableOop.
		primitiveIndex _ self primitiveIndexOf: newMethod.
		"Avoid creating cache entries for PseudoContexts"
		pseudoReceiver = 0 ifTrue: [
			self assert: cls ~= (self splObj: ClassPseudoContext).
			self addToMethodCacheSel: messageSelector
				class: cls
				method: newMethod
				primIndex: primitiveIndex
				translatedMethod: newTranslatedMethod.
		].
	].
