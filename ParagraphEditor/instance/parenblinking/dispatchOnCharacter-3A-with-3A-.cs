dispatchOnCharacter: char with: typeAheadStream
	"Carry out the action associated with this character, if any.
	Type-ahead is passed so some routines can flush or use it."

	| honorCommandKeys |
	self clearParens.
  
	char asciiValue = 13 ifTrue: [
		^ sensor controlKeyPressed
			ifTrue: [self crWithIndent: typeAheadStream]
			ifFalse: [self normalCharacter: typeAheadStream]].

	((honorCommandKeys _ Preferences cmdKeysInText) and: [char = Character enter])
		ifTrue: [^ self dispatchOnEnterWith: typeAheadStream].

	"Special keys overwrite crtl+key combinations - at least on Windows. To resolve this
	conflict, assume that keys other than cursor keys aren't used together with Crtl." 
	((self class specialShiftCmdKeys includes: char asciiValue) and: [char asciiValue < 27])
		ifTrue: [^ sensor controlKeyPressed
			ifTrue: [self perform: (ShiftCmdActions at: char asciiValue + 1) with: typeAheadStream]
			ifFalse: [self perform: (CmdActions at: char asciiValue + 1) with: typeAheadStream]].

	"backspace, and escape keys (ascii 8 and 27) are command keys"
	((honorCommandKeys and: [sensor commandKeyPressed]) or: [self class specialShiftCmdKeys includes: char asciiValue]) ifTrue:
		[^ sensor leftShiftDown
			ifTrue:
				[self perform: (ShiftCmdActions at: char asciiValue + 1) with: typeAheadStream]
			ifFalse:
				[self perform: (CmdActions at: char asciiValue + 1) with: typeAheadStream]].

	"the control key can be used to invoke shift-cmd shortcuts"
	(honorCommandKeys and: [sensor controlKeyPressed])
		ifTrue:
			[^ self perform: (ShiftCmdActions at: char asciiValue + 1) with: typeAheadStream].

	(')]}' includes: char)
		ifTrue: [self blinkPrevParen].

	^ self perform: #normalCharacter: with: typeAheadStream