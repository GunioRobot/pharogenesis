open
	"TelnetMachine open"
	| machine win displayMorph inputMorph |
	Smalltalk isMorphic ifFalse: [ ^self notYetImplemented ].
	
	machine _ self new.

	win _ SystemWindow labelled: 'telnet'.
	win model: machine.

	displayMorph _ PluggableTextMorph on: machine text: #displayBuffer accept: nil readSelection: #displayBufferSelection menu: #menu:shifted:.	
	displayMorph color: Color black.

	inputMorph _ PluggableTextMorph on: machine text: nil accept: #sendLine:.
	inputMorph acceptOnCR: true.

	win addMorph: displayMorph frame: (0@0 extent: 1@0.9).
	win addMorph: inputMorph frame: (0@0.9 extent: 1@0.1).

	displayMorph color: Color black.

	win openInWorld.
