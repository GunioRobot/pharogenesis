openAsMorph
	"open a set of windows for viewing this browser"
	|win urlMorph |

	"create a window for it"
	win _ SystemWindow labelled: 'Scamper'.
	win model: self.
	win setProperty: #webBrowserView toValue: true.

	"create a view of the current url"
	"win addMorph: (RectangleMorph new) frame: (0@0 extent: 0.3@0.1)."
	urlMorph _  PluggableTextMorph on: self text: #currentUrl accept: #jumpToAbsoluteUrl:.
	urlMorph acceptOnCR: true.
	win addMorph: urlMorph frame: (0@0 extent: 1@0.1).

	"create a status view"
	win addMorph: (PluggableTextMorph on: self text: #status accept: nil) frame: (0@0.9 extent: 1.0@0.1).

	"create the text area"
	win addMorph: (WebPageMorph on: self bg: #backgroundColor text: #formattedPage readSelection: #formattedPageSelection menu: #menu:shifted:)
		frame: (0@0.1 extent: 1@0.8).
	
	win openInWorld.
	^win