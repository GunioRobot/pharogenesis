removeDeepFromObjects
	"Remove myself from my objects and then ask
	my subCategories to do the same."

	objects copy do: [:obj | obj removeCategory: self].
	subCategories do: [:cat | cat removeDeepFromObjects]