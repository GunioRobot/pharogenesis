nextString
	"Read a string from the receiver. The first byte is the length of the string, unless it is greater than 192, in which case the first four bytes encode the length.  I expect to be in ascii mode when called (caller puts back to binary)."

	| aString length |

	"read the length in binary mode"
	self binary.
	length _ self next.		"first byte."
	length >= 192 ifTrue: [length _ length - 192.
		1 to: 3 do: [:ii | length _ length * 256 + self next]].
	aString _ String new: length.

	"read the characters in ASCII mode"
	self ascii.
	self nextInto: aString.
	^aString