setSpec: aSpec
	spec := aSpec.
	spec model addDependent: self.
	self refresh.