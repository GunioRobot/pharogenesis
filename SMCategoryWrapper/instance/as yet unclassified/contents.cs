contents
	"This is the message that returns the contents of this wrapper.
	We return a collection of wrappers around all the children of our model."

	^item subCategories collect: [:e | SMCategoryWrapper with: e]