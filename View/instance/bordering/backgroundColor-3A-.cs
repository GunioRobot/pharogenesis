backgroundColor: aColor
	Display depth = 1 ifTrue:
		[(aColor ~= nil and: [aColor isTransparent not]) ifTrue:
			["Avoid stipple due to attempts to match non-whites"
			^ insideColor := Color white]].
	insideColor := aColor