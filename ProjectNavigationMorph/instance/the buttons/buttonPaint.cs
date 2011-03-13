buttonPaint

	| pb oldArgs brush myButton m |

	myButton _ self makeButton: '' balloonText: 'Make a painting' for: #doNewPainting.
	pb _ PaintBoxMorph new submorphNamed: #paint:.
	pb ifNil: [
		(brush _ Form extent: 16@16 depth: 16) fillColor: Color red
	] ifNotNil: [
		oldArgs _ pb arguments.
		brush _ oldArgs third.
		brush _ brush copy: (2@0 extent: 42@38).
		brush _ brush scaledToSize: brush extent // 2.
	].
	myButton addMorph: (m _ brush asMorph lock).
	myButton extent: m extent + (myButton borderWidth + 6).
	m position: myButton center - (m extent // 2).

	^myButton

"brush _ (ScriptingSystem formAtKey: 'Painting')."

