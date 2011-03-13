who
	"Answer an Array of the class in which the receiver is defined and the 
	selector to which it corresponds."
	
	self deprecated: 'use #methodClass and #selector directly'.
	self isInstalled ifFalse: [^#(unknown unknown)].
	^{self methodClass . self selector}.