compile: textOrStream in: aClass notifying: aRequestor ifFail: failBlock 
	"Answer a MethodNode for the argument, textOrStream. If the 
	MethodNode can not be created, notify the argument, aRequestor; if 
	aRequestor is nil, evaluate failBlock instead. The MethodNode is the root 
	of a parse tree. It can be told to generate a CompiledMethod to be 
	installed in the method dictionary of the argument, aClass."

	self from: textOrStream
		class: aClass
		context: nil
		notifying: aRequestor.
	^self
		translate: sourceStream
		noPattern: false
		ifFail: failBlock