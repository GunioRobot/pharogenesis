localColorToGlobal: aColor
	^Color
		r: (aColor red * self rMul + self rAdd)
		g: (aColor green * self gMul + self gAdd)
		b: (aColor blue * self bMul + self bAdd)
		alpha: (aColor alpha * self aMul + self aAdd)