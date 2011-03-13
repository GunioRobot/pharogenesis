removeDeepFromObjects
	"Remove myself from my objects and then ask
	my subCategories to do the same."

	self removeFromObjects.
	subCategories do: [:cat | cat removeDeepFromObjects]