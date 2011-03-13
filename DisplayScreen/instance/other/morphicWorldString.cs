morphicWorldString

	^(self morphicWorldAt: Sensor cursorPoint) hash printString

"===
	aString _ UpdatingStringMorph new target: Display.
	aString useStringFormat; color: Color blue; stepTime: 1000; getSelector: #morphicWorldString.
	aString openInWorld.
==="
