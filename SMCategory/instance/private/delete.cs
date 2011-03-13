delete
	"Delete me. Disconnect me from my objects and my parent.
	Then delete my subcategories."

	super delete.
	self removeFromObjects; removeFromParent.
	self subCategories do: [:c | c delete ]