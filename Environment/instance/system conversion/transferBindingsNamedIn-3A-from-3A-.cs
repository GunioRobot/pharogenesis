transferBindingsNamedIn: nameList from: otherEnvt
	| cls |
	nameList do:
		[:name |
		cls _ otherEnvt at: name.
		self add: (otherEnvt associationAt: name).
		cls environment: self.
		otherEnvt removeKey: name].
