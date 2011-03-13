wsmPackagesByName

	| html id name | 
	
	packages ifNotNil: [ ^packages ].
	
	packages := Dictionary new.
	
	html := self httpGet: (self wsm, 'packagesbyname').
	
	[
		id := html upToAll: '/package/'; upToAll: '">'.
		name := html upTo: $<.
		
		(id notEmpty and: [ name notEmpty ]) 

	] whileTrue: [ packages at: name put: id ].

	^ packages	
	