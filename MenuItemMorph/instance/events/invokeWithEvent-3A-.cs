invokeWithEvent: evt
	"Perform the action associated with the given menu item."

	| selArgCount |
	self isEnabled ifFalse: [^ self].
	(owner isKindOf: MenuMorph) ifTrue: [owner lastSelection: selector].

	Cursor normal showWhile: [  "show cursor in case item opens a new MVC window"
		(selArgCount _ selector numArgs) = 0
			ifTrue:
				[target perform: selector]
			ifFalse:
				[selArgCount = arguments size
					ifTrue: [target perform: selector withArguments: arguments]
					ifFalse: [target perform: selector withArguments: (arguments copyWith: evt)]]]
