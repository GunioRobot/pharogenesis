convert8bitSignedFrom: aByteArray to16Bit: aSoundBuffer
	"Copy the contents of the given array of signed 8-bit samples into the given array of 16-bit signed samples."

	| n s |
	<primitive: 'primitiveConvert8BitSigned' module: 'MiscPrimitivePlugin'>
	self var: #aByteArray declareC: 'unsigned char *aByteArray'.
	self var: #aSoundBuffer declareC: 'unsigned short *aSoundBuffer'.
	n _ aByteArray size.
	1 to: n do: [:i |
		s _ aByteArray at: i.
		s > 127
			ifTrue: [aSoundBuffer at: i put: ((s - 256) bitShift: 8)]
			ifFalse: [aSoundBuffer at: i put: (s bitShift: 8)]].
