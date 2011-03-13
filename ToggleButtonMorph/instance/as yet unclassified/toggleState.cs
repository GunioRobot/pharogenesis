toggleState
	self state: ((state == #off) ifTrue: [#on] ifFalse: [#off])