codePaneMenu: aMenu shifted: shifted 
	ServiceGui browser: self codePaneMenu: aMenu.
	ServiceGui onlyServices ifTrue: [^ aMenu].
	super codePaneMenu: aMenu shifted: shifted.
	^ aMenu