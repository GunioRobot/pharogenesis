minAngle: angle
	maxCos _ angle degreesToRadians cos.
	minCos ifNotNil:[deltaCos _ maxCos - minCos].