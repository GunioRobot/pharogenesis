run: aResult 
	self tests do: [:each | 
		self sunitChanged: each.
		each run: aResult]
			