checkSum: aString
	"Construct a checksum of the string.  A three byte number represented as Base64 characters."

| sum shift bytes ss bb |
sum _ aString size.
shift _ 0.
aString do: [:char |
	(shift _ shift + 7) > 16 ifTrue: [shift _ shift - 17].
		"shift by 7 to keep a change of adjacent chars from xoring to same value"
	sum _ sum bitXor: (char asInteger bitShift: shift)].
bytes _ ByteArray new: 3.
sum _ sum + 16r10000000000.
1 to: 3 do: [:ind | bytes at: ind put: (sum digitAt: ind)].
ss _ ReadWriteStream on: (ByteArray new: 3).
ss nextPutAll: bytes.
bb _ Base64MimeConverter mimeEncode: ss.
^ bb contents