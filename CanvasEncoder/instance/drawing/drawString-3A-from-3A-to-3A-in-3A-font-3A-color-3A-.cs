drawString: s from: firstIndex to: lastIndex in: boundsRect font: fontOrNil color: c
	| fontIndex str |
	fontIndex := self establishFont: (fontOrNil ifNil: [ TextStyle defaultFont ]).
	str _ s asString.
	str isWideString ifTrue: [
		self sendCommand: {
			String with: CanvasEncoder codeMultiText.
			(str copyFrom: firstIndex to: lastIndex) asByteArray asString.
			self class encodeRectangle: boundsRect.
			self class encodeInteger: fontIndex.
			self class encodeColor: c
		}
	] ifFalse: [
		self sendCommand: {
			String with: CanvasEncoder codeText.
			s asString copyFrom: firstIndex to: lastIndex.
			self class encodeRectangle: boundsRect.
			self class encodeInteger: fontIndex.
			self class encodeColor: c
		}
	].
