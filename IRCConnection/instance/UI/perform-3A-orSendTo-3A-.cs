perform: aSelector  orSendTo: editor
	(self respondsTo: aSelector) ifTrue: [
		^self perform: aSelector ].

	^editor perform: aSelector