displayScannerForMulti: para foreground: foreColor background: backColor ignoreColorChanges: shadowMode

	((para isMemberOf: MultiNewParagraph) or: [para text string isByteString]) ifTrue: [
		^ (MultiDisplayScanner new text: para presentationText textStyle: para textStyle
				foreground: foreColor background: backColor fillBlt: self
				ignoreColorChanges: shadowMode)
			setPort: self clone
	].
	^ (DisplayScanner new text: para text textStyle: para textStyle
			foreground: foreColor background: backColor fillBlt: self
			ignoreColorChanges: shadowMode)
		setPort: self clone
