directionArrowTipCenterFor: directionArrow
	| alphaRadians arrowVector result |
	alphaRadians _ target player getHeading degreesToRadians.
	arrowVector _ self directionArrowLength * (alphaRadians sin  @ alphaRadians cos negated).
	result _ (directionArrowAnchor + arrowVector - (0 @ 0)) rounded.
	^ result
