symbolic
	"Answer a String that contains a list of all the byte codes in a method 
	with a short description of each." 
	| aStream |
	self isQuick ifTrue: 
		[self isReturnSpecial ifTrue:
			[^ 'Quick return ' , (#('self' 'true' 'false' 'nil' '-1' '0' '1' '2')
									at: self primitive - 255)].
		^ 'Quick return field ' , self returnField printString , ' (0-based)'].
	aStream _ WriteStream on: (String new: 1000).
	self printPrimitiveOn: aStream.
	(InstructionPrinter on: self) printInstructionsOn: aStream.
	^aStream contents