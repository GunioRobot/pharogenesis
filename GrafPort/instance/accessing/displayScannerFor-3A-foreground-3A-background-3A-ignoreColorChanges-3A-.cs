displayScannerFor: para foreground: foreColor background: backColor ignoreColorChanges: shadowMode
	"Fixed to answer a MultiDisplayScanner when the paragraph is any kind of
	MultiNewParagraph (rather than an instance of the one class) or the paragraph
	text string is a WideString."

	((para isKindOf: MultiNewParagraph) or: [para text string isByteString
			or: [para text string isWideString]]) ifTrue: [
		^ (MultiDisplayScanner new text: para text textStyle: para textStyle
				foreground: foreColor background: backColor fillBlt: self
				ignoreColorChanges: shadowMode)
			setPort: self clone
	].
	^ (DisplayScanner new text: para text textStyle: para textStyle
			foreground: foreColor background: backColor fillBlt: self
			ignoreColorChanges: shadowMode)
		setPort: self clone
