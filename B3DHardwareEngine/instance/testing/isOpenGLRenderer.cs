isOpenGLRenderer
	"D3D doesn't support any line width but 1 so test for that"
	| lw |
	lw _ self lineWidth.
	lw = 1 ifTrue:[
		self lineWidth: 2.
		lw _ self lineWidth.
		self lineWidth: 1.
		^lw = 2].
	^true