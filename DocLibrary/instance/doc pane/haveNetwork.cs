haveNetwork
	
	| hn ask |
	(hn _ NetNameResolver haveNetwork) class == Symbol ifFalse: [^ hn].
	hn == #expired ifTrue: [
		ask _ self confirm: 'OK to connect to the internet?'.
		ask ifFalse: [NetNameResolver haveNetwork: false].
		^ ask].
	^ false