r: r g: g b: b for: depth
	"integer value according depth"
	| val |
	depth = 16 ifTrue: [
		val _ (r << 10) + (g << 5) + b.
	]
	ifFalse:[
		val _ (r << 16) + (g << 8) + b.
	].
	^val
