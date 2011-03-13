buildBrowserCodeView: aBrowser editString: aString

	| aBrowserCodeView |
	aBrowserCodeView _ BrowserCodeView new.
	aBrowserCodeView model: aBrowser.
	aBrowserCodeView window: (0 @ 0 extent: 200 @ 110).
	aBrowserCodeView borderWidthLeft: 2 right: 2 top: 0 bottom: 2.
	aString ~~ nil ifTrue: [aBrowserCodeView editString: aString].
	^aBrowserCodeView