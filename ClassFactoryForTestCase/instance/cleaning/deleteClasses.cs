deleteClasses
	self createdClasses do: [:class|
		self delete: class]