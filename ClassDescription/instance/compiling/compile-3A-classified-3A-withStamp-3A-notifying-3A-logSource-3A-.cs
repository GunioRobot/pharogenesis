compile: text classified: category withStamp: changeStamp notifying: requestor logSource: logSource
	| methodAndNode |
	methodAndNode _ self basicCompile: text asString notifying: requestor 
							trailer: self defaultMethodTrailer ifFail: [^nil].
	logSource ifTrue: [
		self logMethodSource: text forMethodWithNode: methodAndNode 
			inCategory: category withStamp: changeStamp notifying: requestor.
	].
	self addAndClassifySelector: methodAndNode selector withMethod: methodAndNode 
		method inProtocol: category notifying: requestor.
	self theNonMetaClass noteCompilationOf: methodAndNode selector meta: self isMeta.
	^ methodAndNode selector