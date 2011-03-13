checkFirstPairFor: stmt in: obj

	^ self checkRequireVectorIn: stmt for: obj.
"

	| receiver selector ret |
	receiver _ Compiler evaluate: (self getReceiverFromStatement: stmt) name for: obj logged: false.
	selector _ (self getSelectorFromStatement: stmt) key.
	ret _ self isVectorizationRequiredWithPlayer: receiver andSelector: selector.
	attributes setAttribute: #firstTurtle of: stmt to: receiver.
	attributes setAttribute: #requireVector of: stmt to: ret.
	^ ret.
"