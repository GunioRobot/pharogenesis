maxAngle: angle
	minCos _ angle degreesToRadians cos.
	maxCos ifNotNil:[deltaCos _ maxCos - minCos].