messageMenu
	"Answer the menu for the message text pane."

	(currentMsgID notNil)
		ifTrue: [^CustomMenu
			labels: 'again\undo\copy\cut\paste\format\accept\cancel
compose\reply\forward' withCRs
			lines: #(2 5 6 8)
			selections: #(again undo copySelection cut paste format accept cancel
compose reply forward)]
		ifFalse: [^SelectionMenu
			labels: 'again\undo\copy\cut\paste\compose' withCRs
			lines: #(2 5)
			selections: #(again undo copySelection cut paste compose)].