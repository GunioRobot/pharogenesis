hash
	| result |
"WARNING: THE PRIMITIVE SEEMS TO BE BROKEN"
	"<primitive:'primitiveFloatArrayHash'>"
	result _ 0.
	1 to: self size do:[:i| result _ result + (self basicAt: i) ].
	^result bitAnd: 16r1FFFFFFF