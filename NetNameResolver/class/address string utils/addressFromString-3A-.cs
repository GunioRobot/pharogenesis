addressFromString: addressString
	"Return the internet address represented by the given string. The string should contain four positive decimal integers delimited by periods, commas, or spaces, where each integer represents one address byte. Return nil if the string is not a host address in an acceptable format."
	"NetNameResolver addressFromString: '1.2.3.4'"
	"NetNameResolver addressFromString: '1,2,3,4'"
	"NetNameResolver addressFromString: '1 2 3 4'"

	| newAddr s byte delimiter |
	newAddr _ ByteArray new: 4.
	s _ ReadStream on: addressString.
	s skipSeparators.
	1 to: 4 do: [:i |
		byte _ self readDecimalByteFrom: s.
		byte = nil ifTrue: [^ nil].
		newAddr at: i put: byte.
		i < 4 ifTrue: [
			delimiter _ s next.
			((delimiter = $.) or: [(delimiter = $,) or: [delimiter = $ ]])
				ifFalse: [^ nil]]].
	^ newAddr
