jumplfTrueBy: offset

	| boolean |
	boolean _ self internalStackTop.
	boolean = trueObj ifTrue: [
		self jump: offset.
	] ifFalse: [
		boolean = falseObj ifFalse: [
			messageSelector _ self splObj: SelectorMustBeBoolean.
			argumentCount _ 0.
			^ self normalSend
		].
	].
	self internalPop: 1.
