fillStyle
	"Return the current fillStyle of the receiver."
	
	extension ifNil: [^color].
	
	^ self
		valueOfProperty: #fillStyle
		ifAbsent: ["Workaround already converted morphs"
			color]