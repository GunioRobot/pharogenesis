method1
	"(CCodeGenerator new initialize addClass: TestCClass1) codeString"

	x & y ifTrue: [
		x _ 10.
		y _ 20.
	].
	y _ nil + 3.
	x = nil ifTrue: [ x _ 18 ].
	^nil