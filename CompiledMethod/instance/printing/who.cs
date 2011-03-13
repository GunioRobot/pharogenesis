who 
	"Answer an Array of the class in which the receiver is defined and the 
	selector to which it corresponds."

	Smalltalk allBehaviorsDo:
		[:class |
		class selectorsDo:
			[:sel |
			(class compiledMethodAt: sel) == self 
				ifTrue: [^Array with: class with: sel]]]