receiver: rcvr selector: aSelector arguments: args precedence: p from: encoder 
	"Compile."

	| theSelector |
	self receiver: rcvr
		arguments: args
		precedence: p.
	aSelector = #':Repeat:do:'
		ifTrue: [theSelector _ #do:]
		ifFalse: [theSelector _ aSelector].
	self noteSpecialSelector: theSelector.
	(self transform: encoder)
		ifTrue: 
			[selector isNil
				ifTrue: [selector _ SelectorNode new 
							key: (MacroSelectors at: special)
							code: #macro]]
		ifFalse: 
			[selector _ encoder encodeSelector: theSelector.
			rcvr == NodeSuper ifTrue: [encoder noteSuper]].
	self pvtCheckForPvtSelector: encoder