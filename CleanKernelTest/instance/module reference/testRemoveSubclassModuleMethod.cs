testRemoveSubclassModuleMethod
	self 
		deny: (self isSelector: #subclass:instanceVariableNames:classVariableNames:poolDictionaries:category:module: definedInClass: #Class)