testNew
	self	should: [ContextPart new: 5] raise: Error.
	[ContextPart new: 5]
		ifError: [:error :receiver | error = 'Error: Contexts must only be created with newForMethod:'].
	[ContextPart new]
		ifError: [:error :receiver | error = 'Error: Contexts must only be created with newForMethod:'].	
	[ContextPart basicNew]
		ifError: [:error :receiver | error = 'Error: Contexts must only be created with newForMethod:'].				

