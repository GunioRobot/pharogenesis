widthOfString: aString

	aString ifNil:[^0].
	"Optimizing"
	(aString isKindOf: String) ifTrue: [
		^ self fontArray first widthOfString: aString from: 1 to: aString size].
	^ self widthOfString: aString from: 1 to: aString size.
"
	TextStyle default defaultFont widthOfString: 'zort' 21
"
