primitiveClipboardText
	"When called with a single string argument, post the string to the clipboard. When called with zero arguments, return a string containing the current clipboard contents."

	| s sz |
	argumentCount = 1 ifTrue: [
		s _ self stackTop.
		self successIfClassOf: s is: (self splObj: ClassString).
		successFlag ifTrue: [
			sz _ self stSizeOf: s.
			self clipboardWrite: sz From: (s + BaseHeaderSize) At: 0.
			self pop: 1.  "pop s, leave rcvr on stack"
		].
	] ifFalse: [
		sz _ self clipboardSize.
		s _ self instantiateClass: (self splObj: ClassString)
					  indexableSize: sz.
		self clipboardRead: sz Into: (s + BaseHeaderSize) At: 0.
		self pop: 1.  "rcvr"
		self push: s.
	].
