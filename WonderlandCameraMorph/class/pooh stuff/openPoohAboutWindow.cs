openPoohAboutWindow
	"WonderlandCameraMorph openPoohAboutWindow"
	| window image text button extent |

	extent _ Display extent // 3 * (1.5@1.5).

	window _ SystemWindow labelled: 'About Pooh'.

	image _ (ImageMorph new image: self poohAboutImage).
	text _ TextMorph new contentsWrapped: self poohAboutText; occlusionsOnOff.
	button _ SimpleButtonMorph new label: 'Ok'; target: window; actionSelector: #delete.

	window addMorph: text frame: (0.01@0.01 corner: 0.99@0.84).
	window addMorph: image frame: (0.01@0.01 corner: 0.99@0.84).
	window addMorph: button frame: (0.45@0.85 corner: 0.55@0.99).

	window setWindowColor: Color white;
		color: Color white.

	window openInWorldExtent: extent.
