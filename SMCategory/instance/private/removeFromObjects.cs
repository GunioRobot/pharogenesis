removeFromObjects
	"Remove myself from my objects."

	objects copy do: [:obj | obj removeCategory: self]