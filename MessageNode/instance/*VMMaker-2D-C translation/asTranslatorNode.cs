asTranslatorNode
"make a CCodeGenerator equivalent of me"
	"selector is sometimes a Symbol, sometimes a SelectorNode!
	On top of this, numArgs is needed due to the (truly grody) use of
	arguments as a place to store the extra expressions needed to generate
	code for in-line to:by:do:, etc.  see below, where it is used."
	| sel args |
	sel _ (selector isMemberOf: Symbol) ifTrue: [selector] ifFalse: [selector key].
	args _ (1 to: sel numArgs) collect:
			[:i | (arguments at: i) asTranslatorNode].
	(sel = #to:by:do: and: [arguments size = 7 and: [(arguments at: 7) notNil]])
		ifTrue: ["Restore limit expr that got moved by transformToDo:"
				args at: 1 put: (arguments at: 7) value asTranslatorNode].
	(sel = #or: and: [arguments size = 2 and: [(arguments at: 2) notNil]])
		ifTrue: ["Restore argument block that got moved by transformOr:"
				args at: 1 put: (arguments at: 2) asTranslatorNode].
	(sel = #ifFalse: and: [arguments size = 2 and: [(arguments at: 2) notNil]])
		ifTrue: ["Restore argument block that got moved by transformIfFalse:"
				args at: 1 put: (arguments at: 2) asTranslatorNode].
	^ TSendNode new
		setSelector: sel
		receiver: ((receiver == nil)
					ifTrue: [nil]
					ifFalse: [receiver asTranslatorNode])
		arguments: args