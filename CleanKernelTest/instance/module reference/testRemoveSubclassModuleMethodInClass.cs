testRemoveSubclassModuleMethodInClass
	self
		deny: (self isSelector: #existingCategoryFor:orConvert:   definedInClass: #Class).
	self
		deny: (self isSelector: #subclass:instanceVariableNames:classVariableNames:module:  definedInClass: #Class).
self
		deny: (self isSelector: #variableByteSubclass:instanceVariableNames:classVariableNames:module: definedInClass: #Class).
self
		deny: (self isSelector: #variableSubclass:instanceVariableNames:classVariableNames:module: definedInClass: #Class).
self
		deny: (self isSelector: #variableWordSubclass:instanceVariableNames:classVariableNames:module: definedInClass: #Class).
self
		deny: (self isSelector: #weakSubclass:instanceVariableNames:classVariableNames:module:  definedInClass: #Class).
