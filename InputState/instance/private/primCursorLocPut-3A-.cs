primCursorLocPut: aPoint 
	"Primitive. Move the cursor to the screen location specified by the
	argument, aPoint. Fail if the argument is not a Point. Essential. See
	Object documentation whatIsAPrimitive."

	<primitive: 91>
	^self primCursorLocPutAgain: aPoint rounded