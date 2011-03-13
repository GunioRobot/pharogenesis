openMotd
	"open a view on the MOTD"
	| win textView updateButton |

	win _ SystemWindow labelled: 'MOTD'.

	textView _ PluggableTextMorph on: self text: #motd accept: nil.
	win addMorph: textView  frame: (0@0 extent: 1@0.9).

	updateButton _ PluggableButtonMorph on: self getState: nil action: #requestMotd.
	updateButton
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		label: 'update'.
	win addMorph: updateButton  frame: (0@0.9 extent: 1@0.1).

	win openInWorld.