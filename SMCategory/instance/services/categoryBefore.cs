categoryBefore
	"Return the category listed before me in my parent.
	If I am first or I have no parent, return nil."

	parent isNil ifTrue:[^nil].
	parent subCategories first = self ifTrue:[^nil].
	^parent subCategories before: self
	