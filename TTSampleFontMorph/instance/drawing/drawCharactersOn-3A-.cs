drawCharactersOn: aCanvas
	| glyph origin r offset cy m |
	0 to: 255 do:[:i|
		glyph _ font at: i.
		origin _ font bounds extent * ((i \\ 16) @ (i // 16)).
		r _ origin extent: font bounds extent.
		offset _ r center - glyph bounds center.
		cy _ glyph bounds center y.
		m _ MatrixTransform2x3 withOffset: 0@cy.
		m _ m composedWithLocal: (MatrixTransform2x3 withScale: 1@-1).
		m _ m composedWithLocal: (MatrixTransform2x3 withOffset: 0@cy negated).
		m _ m composedWithGlobal: (MatrixTransform2x3 withOffset: offset).
		aCanvas asBalloonCanvas preserveStateDuring:[:balloonCanvas|
			balloonCanvas transformBy: m.
			balloonCanvas drawGeneralBezierShape: glyph contours
					color: color
					borderWidth: 0
					borderColor: Color black.
		].
	].