dispatchOnKeyEvent: keyEvent with: typeAheadStream
	"Carry out the action associated with this character, if any.
	Type-ahead is passed so some routines can flush or use it."

	| honorCommandKeys keyValue keyChar char action |
	self clearParens.
	keyValue := OSPlatform current virtualKey: keyEvent scanCode.
  	keyValue := keyValue ifNil: [keyEvent keyValue].
	"Work around bug in some VMs delivering negative key values"
	keyChar := (keyValue max: 0) asCharacter.
	char := keyEvent keyCharacter.
	
	"mikki 1/3/2005 21:31 Preference for auto-indent on return added."
	keyChar = Character cr ifTrue: [
		^(Preferences autoIndent 
			xor: keyEvent controlKeyPressed)
			ifTrue: [self crWithIndent: typeAheadStream]
			ifFalse: [self normalCharacter: typeAheadStream character: char]].

	((honorCommandKeys := Preferences cmdKeysInText)
		and: [keyChar = Character enter])
		ifTrue: [^ self dispatchOnEnterWith: typeAheadStream].
		
	keyValue < 256 ifTrue: [	"none of the following is safe if the character's asciiValue is out of the 0..255 range"
		
	"Special keys overwrite crtl+key combinations - at least on Windows. To resolve this
	conflict, assume that keys other than cursor keys aren't used together with Crtl." 
	((self class specialShiftCmdKeys includes: keyValue) and: [keyValue < 27])
		ifTrue: [
			action := keyEvent controlKeyPressed
				ifTrue: [ShiftCmdActions at: keyValue + 1]
				ifFalse: [CmdActions at: keyValue + 1].
			^action numArgs = 1
				ifTrue: [self perform: action with: typeAheadStream]
				ifFalse: [self perform: action with: keyEvent with: typeAheadStream]].

	"backspace, and escape keys (ascii 8 and 27) are command keys"
	((honorCommandKeys and: [keyEvent commandKeyPressed]) or: [self class specialShiftCmdKeys includes: keyValue])
		ifTrue: [
			action := keyEvent leftShiftDown
					ifTrue: [ShiftCmdActions at: keyValue + 1]
					ifFalse: [CmdActions at: keyValue + 1].
			^action numArgs = 1
				ifTrue: [self perform: action with: typeAheadStream]
				ifFalse: [self perform: action with: typeAheadStream with: keyEvent]].

	"the control key can be used to invoke shift-cmd shortcuts"
	(honorCommandKeys and: [keyEvent controlKeyPressed])
		ifTrue: [
			action := ShiftCmdActions at: keyValue + 1.
			^action numArgs = 1
				ifTrue: [self perform: action with: typeAheadStream]
				ifFalse: [self perform: action with: typeAheadStream with: keyEvent]].
	
	"allow cut/copy/paste/selectAll regardless of cmdKeysInText preference.
	Useful when running a deployed/locked-down image (after disableProgrammerFacilities)."
	((#(cut: copySelection: paste: selectAll:) includes: (CmdActions at: keyValue + 1)) 
		and: [keyEvent commandKeyPressed])
		ifTrue: [
			action := CmdActions at: keyValue + 1.
			^action numArgs = 1
				ifTrue: [self perform: action with: typeAheadStream]
				ifFalse: [self perform: action with: typeAheadStream with: keyEvent]].
	]. "end of range protection"

	(')]}' includes: char)
		ifTrue: [self blinkPrevParen: char].

	^self normalCharacter: typeAheadStream character: char