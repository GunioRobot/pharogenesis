readByteArray
	"PRIVATE -- Read the contents of a ByteArray."
	| count buffer |

	count _ byteStream nextNumber: 4.
	^ (ByteArray new: count)
		replaceFrom: 1 to: count with: (byteStream next: count)