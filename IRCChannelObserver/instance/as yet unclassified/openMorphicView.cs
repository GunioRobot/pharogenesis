openMorphicView
	"open a view for interacting with this collector"
	| win textArea inputArea topicArea usersButton |

	win _ SystemWindow new.
	win setLabel: channel name.
	win model: self.

	topicArea _ PluggableTextMorph on: channel  text: #topic  accept: #changeTopic:.
	topicArea acceptOnCR: true.
	win addMorph: topicArea frame: (0@0 extent: 0.9@0.1).

	usersButton _ PluggableButtonMorph on: channel  getState: nil  action: #openUserList.
	usersButton
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		label: 'users'.
	win addMorph: usersButton frame: (0.9@0 extent: 0.1@0.1).

	textArea _ PluggableTextMorph on: self text: #chatText accept: nil readSelection: #chatTextSelection menu: nil.
	win addMorph: textArea frame: (0@0.1 extent: 1@0.8).

	inputArea _ PluggableTextMorph on: self text: nil accept: #sendMessage:.
	inputArea acceptOnCR: true.
	win addMorph: inputArea frame: (0@0.9 extent: 1@0.1) .

	win openInWorld.