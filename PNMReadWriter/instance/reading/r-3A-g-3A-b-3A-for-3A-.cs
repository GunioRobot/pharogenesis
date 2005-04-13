r: r g: g b: b for: aDepth
	"integer value according depth"
	| val |
	aDepth = 16 ifTrue: [
		val _ (r << 10) + (g << 5) + b.
	]
	ifFalse:[
		val _ (r << 16) + (g << 8) + b.
	].
	^val
