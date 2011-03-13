handleDisabledKey: anEvent
	"Handle a key character when the text morph is disabled."

	|ascii cmds cmd|
	ascii := anEvent keyValue.
	ascii < 256 ifFalse: [^self].
	cmds := #(). cmd := nil.
	(anEvent commandKeyPressed or: [self class specialShiftCmdKeys includes: ascii]) ifTrue: [
		cmd := anEvent shiftPressed
			ifTrue: [ShiftCmdActions at: ascii + 1]
			ifFalse: [CmdActions at: ascii + 1].
		Preferences cmdKeysInText
			ifTrue: [cmds := self disabledCommandActions]
			ifFalse: [cmds := #(copySelection: selectAll:)]].	
	(cmds includes: cmd) ifTrue: [
		self deselect.
		(cmd numArgs = 1
			ifTrue: [self perform: cmd with: String new readStream]
			ifFalse: [self perform: cmd with: String new readStream with: anEvent])
				ifTrue: [self
					doneTyping;
					setEmphasisHere;
					selectAndScroll;
					updateMarker]]