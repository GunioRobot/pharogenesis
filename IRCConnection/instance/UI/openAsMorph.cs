openAsMorph
	| win consolePane inputPane |

	"build views"
	win _ SystemWindow labelled: 'IRC'.
	win model: self.

	consolePane _ PluggableTextMorph on: self text: #consoleText accept: nil readSelection: #consoleTextSelection menu: #consoleMenu:.
	win addMorph: consolePane frame: (0@0 extent: 1@0.9).

	inputPane _ PluggableTextMorph on: self text: nil accept: #sendRawCommand:.
	inputPane acceptOnCR: true.
	win addMorph: inputPane  frame: (0@0.9 extent: 1@0.1).


	"subscribe to protocol messages and direct messages, so we can display them on console"
	self subscribeToDirectMessages: self.
	self subscribeToProtocolMessages: self.

	win openInWorld