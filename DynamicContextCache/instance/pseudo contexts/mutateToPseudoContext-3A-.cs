mutateToPseudoContext: aContext
	"Change the class of aContext to PseudoContext and set the entire contents to nil."

	| nilOop |
	self inline: true.
	self assertIsStableContext: aContext.
	self changeClassOf: aContext to: (self splObj: ClassPseudoContext).

"IS THIS NECESSARY?"
	nilOop _ nilObj.
	self fill:		((self sizeBitsOf: aContext) - BaseHeaderSize) // 4 - 1
		wordsFrom:	aContext + BaseHeaderSize
		with:		nilOop.
