warpBits
	canvas gsave.
	transform ~= nil ifTrue: [ canvas transformBy:transform ].
	canvas drawPostscriptContext:subCanvas.
	canvas grestore.

	^self. 