repositories
	"Answer an ordered collection of repositories."
	
	| repositories |
	repositories := OrderedCollection new.
	self repository isNil 
		ifTrue: [ 
			self workingCopy isNil 
				ifFalse: [ repositories addAll: self workingCopy repositoryGroup repositories ] ]	
		ifFalse: [
			self repository isRepositoryGroup
				ifFalse: [ repositories add: self repository ]
				ifTrue: [ repositories addAll: self repository repositories ] ].
	repositories := repositories select: [ :each | 
		each isValid and: [ each ~= MCCacheRepository default ] ].
	^ repositories