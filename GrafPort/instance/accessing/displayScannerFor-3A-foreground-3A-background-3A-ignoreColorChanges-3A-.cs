displayScannerFor: para foreground: foreColor background: backColor ignoreColorChanges: shadowMode

	((para isMemberOf: MultiNewParagraph) or: [para text string class == String]) ifTrue: [
		^ (MultiDisplayScanner new text: para text textStyle: para textStyle
				foreground: foreColor background: backColor fillBlt: self
				ignoreColorChanges: shadowMode)
			setPort: self clone
	].
	^ (DisplayScanner new text: para text textStyle: para textStyle
			foreground: foreColor background: backColor fillBlt: self
			ignoreColorChanges: shadowMode)
		setPort: self clone
