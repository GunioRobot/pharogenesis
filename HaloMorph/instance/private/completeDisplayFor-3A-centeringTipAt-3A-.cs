completeDisplayFor: directionHandle centeringTipAt: aPosition

	| aShaft  |
	self correctlyRotateDirectionArrow: directionHandle forDegrees: 
			(directionArrowAnchor bearingToPoint: aPosition) .
	directionHandle position: (aPosition - (directionHandle extent // 2)).

	aShaft _ self submorphThat:
		[:aSubMorph | aSubMorph isKindOf: PolygonMorph] ifNone: [PolygonMorph new color: Color orange; borderColor: Color orange; borderWidth: 3].
	aShaft setVertices: (Array with: aPosition with: directionArrowAnchor).
	self addMorph: aShaft.
	self layoutChanged