asByteArray
	"Convert to a ByteArray with the ascii values of the string.
	Fast code uses primitive that avoids character conversion"

	^ (ByteArray new: self size) replaceFrom: 1 to: self size with: self