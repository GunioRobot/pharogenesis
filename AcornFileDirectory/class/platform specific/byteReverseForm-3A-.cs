byteReverseForm: aForm
	"Byte-reverse the words of the given Form's bitmap. Supports porting a Squeak image to the Acorn."

	| bits w reversedW |
	bits _ aForm bits.
	1 to: bits size do: [:i |
		w _ bits at: i.
		reversedW _ Integer
			byte1: (w digitAt: 4)
			byte2: (w digitAt: 3)
			byte3: (w digitAt: 2)
			byte4: (w digitAt: 1).
		bits at: i put: reversedW].
