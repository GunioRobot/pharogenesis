addDirectionShaft

	| directionHandle shaft info |
	directionArrowAnchor _ target referencePositionInWorld.

	self addMorphFront: (shaft _ PolygonMorph newSticky).
	shaft makeOpen; borderWidth: 5; borderColor: Color orange.
	shaft setCenteredBalloonText: 'Forward direction'.
	info _ self positionDirectionShaft: shaft.

	directionHandle _ self addGraphicalHandle: #Direction at: info first  on: #mouseDown send: #doDirection:with: to: self.
	self correctlyRotateDirectionArrow: directionHandle forDegrees: target player getHeading.

	directionHandle center: info first.
	directionHandle on: #mouseStillDown send: #trackDirectionArrow:with: to: self.
	directionHandle on: #mouseUp send: #setDirection:with: to: self.
	directionHandle setProperty: #helpAtCenter toValue: true.

	self completeDisplayFor: directionHandle centeringTipAt: (self directionArrowTipCenterFor: directionHandle).
