invokeItem: aMenuItem
	"Perform the action associated with the given menu item."

	| sel target args selArgCount |
	aMenuItem isEnabled ifFalse: [^ self].
	lastSelection _ aMenuItem.
	"to do: report lastSelection"
	sel _ aMenuItem selector.
	target _ aMenuItem target.
	args _ aMenuItem arguments.
	selArgCount _ sel numArgs.
	Cursor normal showWhile: [  "show cursor in case item opens a new MVC window"
		selArgCount = 0
			ifTrue: [target perform: sel]
			ifFalse: [
				selArgCount = args size
					ifTrue: [target perform: sel withArguments: args]
					ifFalse: [target perform: sel withArguments: (args copyWith: originalEvent)]]].
