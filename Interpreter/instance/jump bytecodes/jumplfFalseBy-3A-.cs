jumplfFalseBy: offset

	| boolean |
	boolean _ self internalStackTop.
	boolean = falseObj ifTrue: [
		self jump: offset.
	] ifFalse: [
		boolean = trueObj ifFalse: [
			messageSelector _ self splObj: SelectorMustBeBoolean.
			argumentCount _ 0.
			^ self normalSend
		].
	].
	self internalPop: 1.
