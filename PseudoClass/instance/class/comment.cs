comment
	| rStr |
	rStr := self organization commentRemoteStr.
	^rStr isNil
		ifTrue:[self name,' has not been commented']
		ifFalse:[rStr string]