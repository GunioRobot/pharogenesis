closeTo: num
	"are these two numbers close?"
	| fuzz ans |
	num isNumber ifFalse: [
		[ans _ self = num] ifError: [:aString :aReceiver | ^ false].
		^ ans].
	self = 0.0 ifTrue: [^ num abs < 0.0001].
	num = 0.0 ifTrue: [^ self abs < 0.0001].
	self isNaN == num isNaN ifFalse: [^ false].
	self isInfinite == num isInfinite ifFalse: [^ false].
	fuzz := (self abs max: num abs) * 0.0001.
	^ (self - num) abs <= fuzz