invokeScoreMenu: evt
	"Invoke the score's edit menu."

	| menu subMenu |
	menu _ MenuMorph new defaultTarget: self.
	menu addList:
		#(('cut'		cutSelection)
		('copy'		copySelection)
		('paste'		insertSelection)
		('paste...'	insertTransposed)).
	menu addLine.
	menu addList:
		#(('legato'		selectionBeLegato)
		('staccato'		selectionBeStaccato)
		('normal'		selectionBeNormal)).
	menu addLine.
	menu addList:
		#(('expand time'		expandTime)
		('contract time'		contractTime)).
	menu addLine.
	subMenu _ MenuMorph new defaultTarget: self.
		(2 to: 12) do: [:i | subMenu add: i printString selector: #beatsPerMeasure: argument: i].
		menu add: 'time   ', beatsPerMeasure printString subMenu: subMenu.
	subMenu _ MenuMorph new defaultTarget: self.
		#(2 4 8) do: [:i | subMenu add: i printString selector: #notePerBeat: argument: i].
		menu add: 'sig     ', notePerBeat printString subMenu: subMenu.
	menu addLine.
	showMeasureLines
		ifTrue: [menu add: 'hide measure lines' action: #measureLinesOnOff]
		ifFalse: [menu add: 'show measure lines' action: #measureLinesOnOff].
	showBeatLines
		ifTrue: [menu add: 'hide beat lines' action: #beatLinesOnOff]
		ifFalse: [menu add: 'show beat lines' action: #beatLinesOnOff].

	menu addLine.
	menu add: 'add keyboard' action: #addKeyboard.

	menu popUpEvent: evt in: self world.
