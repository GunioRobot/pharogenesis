vHideScrollBar

	self keepScrollBarAlways ifTrue: [^self].
	^super vHideScrollBar