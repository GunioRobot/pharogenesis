check
	"Sanity checks."

	"SMSqueakMap default check"
	
	(((self packages inject: 0 into: [:sum :p | sum := sum + p releases size]) +
	self accounts size +
	self packages size +
	self categories size) = SMSqueakMap default objects size)
		ifFalse: [self error: 'Count inconsistency in map'].
	
	objects do: [:o |
		o map == self
			ifFalse: [self error: 'Object with wrong map']].
	self packages do: [:p |
		(p releases allSatisfy: [:r | r map == self])
			ifFalse: [self error: 'Package with release pointing to wrong map']].
		
	self packageReleases do: [:r |
		r package map == self ifFalse: [self error: 'Release pointing to package in wrong map']]