tellAllSiblings: aMessageSelector
	"Send the given message selector to all my sibling instances, but not to myself"

	self belongsToUniClass ifTrue:
		[(self class allSubInstances copyWithout: self) do:
			[:anInstance | anInstance perform: aMessageSelector]]