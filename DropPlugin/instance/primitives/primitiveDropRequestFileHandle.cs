primitiveDropRequestFileHandle
	"Note: File handle creation needs to be handled by specific support code explicitly bypassing the plugin file sand box."
	| dropIndex handleOop |
	self export: true.
	self inline: false.
	interpreterProxy methodArgumentCount = 1 
		ifFalse:[^interpreterProxy primitiveFail].
	dropIndex _ interpreterProxy stackIntegerValue: 0.
	handleOop _ self dropRequestFileHandle: dropIndex.
	"dropRequestFileHandle needs to return the actual oop returned"
	interpreterProxy failed ifFalse:[
		interpreterProxy pop: 2.
		interpreterProxy push: handleOop.
	].