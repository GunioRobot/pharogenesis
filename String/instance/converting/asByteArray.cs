asByteArray
	"Convert to a ByteArray with the ascii values of the string"
	| array |
	array _ ByteArray new: self size.
	1 to: array size do: [:index |
		array at: index put: (self at: index) asciiValue].
	^ array