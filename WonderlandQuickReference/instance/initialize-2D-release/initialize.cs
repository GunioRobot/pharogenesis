initialize
	"Create a modified workspace as our script editor"

	super initialize.

	myTextEditor _ (PluggableTextMorph on: self text: #contents accept: #acceptContents:
			readSelection: nil menu: #codePaneMenu:shifted:).

	myTextEditor name: 'Quick Reference'.
	myTextEditor scrollBarOnLeft: false.
	myTextEditor retractable: false.
	myTextEditor extent: 500@350.
	myTextEditor color: (Color r: 0.815 g: 0.972 b: 0.878).
