ascent
	"Use a cached copy if available"
	ascent ifNil:[
		ascent := ttcDescription ascender * self pixelSize // (ttcDescription ascender - ttcDescription descender) * Scale y.
	(fallbackFont notNil and: [fallbackFont ascent > ascent])
		ifTrue: [ascent := fallbackFont ascent].
	].
	^ascent