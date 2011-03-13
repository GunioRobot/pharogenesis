store15To24HexBitsOn:aStream

	| buf i |

	"write data for 16-bit form, optimized for encoders writing directly to files to do one single file write rather than 12. I'm not sure I understand the significance of the shifting pattern, but I think I faithfully translated it from the original"

	buf _ String new: 12.
	bits do: [:word | 
		i _ 0.
		"upper pixel"
		buf at: (i _ i + 1) put: ((word bitShift: -27) bitAnd: 15) asHexDigit.
		buf at: (i _ i + 1) put: ((word bitShift: -32) bitAnd: 8) asHexDigit.

		buf at: (i _ i + 1) put: ((word bitShift: -22) bitAnd: 15) asHexDigit.
		buf at: (i _ i + 1) put: ((word bitShift: -27) bitAnd: 8) asHexDigit.

		buf at: (i _ i + 1) put: ((word bitShift: -17) bitAnd: 15) asHexDigit.
		buf at: (i _ i + 1) put: ((word bitShift: -22) bitAnd: 8) asHexDigit.

		"lower pixel"

		buf at: (i _ i + 1) put: ((word bitShift: -11) bitAnd: 15) asHexDigit.
		buf at: (i _ i + 1) put: ((word bitShift: -16) bitAnd: 8) asHexDigit.

		buf at: (i _ i + 1) put: ((word bitShift: -6) bitAnd: 15) asHexDigit.
		buf at: (i _ i + 1) put: ((word bitShift: -11) bitAnd: 8) asHexDigit.

		buf at: (i _ i + 1) put: ((word bitShift: -1) bitAnd: 15) asHexDigit.
		buf at: (i _ i + 1) put: ((word bitShift: -6) bitAnd: 8) asHexDigit.
		aStream print: buf.
		"#( 31 26 21 15 10 5 )  do:[:startBit | ]"
	].