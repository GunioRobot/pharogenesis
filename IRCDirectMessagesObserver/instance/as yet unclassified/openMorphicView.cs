openMorphicView
	"open a view for messages sent here"
	| win textArea inputArea |

	win _ SystemWindow new.
	win setLabel: (talkingTo ifNotNil: [ talkingTo ] ifNil: [ 'private messages' ]).
	win model: self.

	textArea _ PluggableTextMorph on: self text: #chatText accept: nil readSelection: #chatTextSelection menu: nil.

	talkingTo
		ifNil: [ win addMorph: textArea frame: (0@0 extent: 1@1) ]
		ifNotNil: [
			win addMorph: textArea  frame: (0@0 extent: 1@0.9).

			inputArea _ PluggableTextMorph on: self text: nil accept: #sendMessage:.
			inputArea acceptOnCR: true.
			win addMorph: inputArea  frame: (0@0.9 extent: 1@0.1) ].

	win openInWorld.