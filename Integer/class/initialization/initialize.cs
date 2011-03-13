initialize  "Integer initialize"
	SinArray _ (0 to: 90) collect: [:x | x asFloat degreesToRadians sin].
	"Return integral values for 90-degree multiples"
	SinArray at: 1 put: 0.
	SinArray at: 91 put: 1