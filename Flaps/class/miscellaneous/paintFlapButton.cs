paintFlapButton
	"Answer a button to serve as the paint flap"

	| pb oldArgs brush myButton m |
	pb _ PaintBoxMorph new submorphNamed: #paint:.
	pb
		ifNil:
			[(brush _ Form extent: 16@16 depth: 16) fillColor: Color red]
		ifNotNil:
			[oldArgs _ pb arguments.
			brush _ oldArgs third.
			brush _ brush copy: (2@0 extent: 42@38).
			brush _ brush scaledToSize: brush extent // 2].
	myButton _ BorderedMorph new.
	myButton color: (Color r: 0.833 g: 0.5 b: 0.0); borderWidth: 2; borderColor: #raised.
	myButton addMorph: (m _ brush asMorph lock).
	myButton extent: m extent + (myButton borderWidth + 6).
	m position: myButton center - (m extent // 2).
	^ myButton

