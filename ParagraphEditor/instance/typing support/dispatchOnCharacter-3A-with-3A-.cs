dispatchOnCharacter: char with: typeAheadStream
	"Carry out the action associated with this character, if any.
	Type-ahead is passed so some routines can flush or use it."

	"enter, backspace, and escape keys (ascii 3, 8, and 27) are command keys"
	(sensor commandKeyPressed or: [#(3 8 27) includes: char asciiValue]) ifTrue: [
		sensor leftShiftDown ifTrue: [
			^ self perform: (ShiftCmdActions at: char asciiValue + 1) with: typeAheadStream.
		] ifFalse: [
			^ self perform: (CmdActions at: char asciiValue + 1) with: typeAheadStream.
		].
	].

	"the control key can be used to invoke shift-cmd shortcuts"
	sensor controlKeyPressed ifTrue: [
		^ self perform: (ShiftCmdActions at: char asciiValue + 1) with: typeAheadStream.
	].
	^ self perform: #normalCharacter: with: typeAheadStream