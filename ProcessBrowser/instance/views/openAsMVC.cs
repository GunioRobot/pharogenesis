openAsMVC
	"Create a pluggable version of me, answer a window"
	| window processListView stackListView methodTextView |
	window _ StandardSystemView new model: self controller: (deferredMessageRecipient _ DeferredActionStandardSystemController new).
	window borderWidth: 1.
	processListView _ PluggableListView
				on: self
				list: #processNameList
				selected: #processListIndex
				changeSelected: #processListIndex:
				menu: #processListMenu:
				keystroke: #processListKey:from:.
	processListView
		window: (0 @ 0 extent: 300 @ 200).
	window addSubView: processListView.
	stackListView _ PluggableListView
				on: self
				list: #stackNameList
				selected: #stackListIndex
				changeSelected: #stackListIndex:
				menu: #stackListMenu:
				keystroke: #stackListKey:from:.
	stackListView
		window: (300 @ 0 extent: 300 @ 200).
	window addSubView: stackListView toRightOf: processListView.
	methodTextView _ PluggableTextView
				on: self
				text: #selectedMethod
				accept: nil
				readSelection: nil
				menu: nil.
	methodTextView askBeforeDiscardingEdits: false.
	methodTextView
		window: (0 @ 200 corner: 600 @ 400).
	window addSubView: methodTextView below: processListView.
	window setUpdatablePanesFrom: #(#processNameList #stackNameList ).
	window label: 'Process Browser'.
	window minimumSize: 300 @ 200.
	window subViews
		do: [:each | each controller].
	window controller open.
	startedCPUWatcher ifTrue: [ self setUpdateCallbackAfter: 7 ].
	^ window