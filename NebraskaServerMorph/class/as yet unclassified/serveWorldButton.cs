serveWorldButton

	| button |
	button _ ScriptableButton new.
	button target: NebraskaServerMorph.
	button actionSelector: #serveWorld.
	button arguments: #().
	button label: 'Share'.
	button color: Color yellow.
	^ button.
