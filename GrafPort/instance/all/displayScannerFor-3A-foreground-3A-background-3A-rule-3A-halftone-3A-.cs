displayScannerFor: para foreground: foreColor background: backColor
		rule: rule halftone: halftone

	^ (DisplayScanner new text: para text textStyle: para textStyle
			foreground: foreColor background: backColor fillBlt: self)
		setDestForm: destForm sourceForm: destForm
			fillColor: halftone combinationRule: rule
			destOrigin: 0@0 sourceOrigin: 0@0
			extent: 0@0 clipRect: self clipRect