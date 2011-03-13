= anotherPackage
	self hash = anotherPackage hash ifFalse: [ ^false ].

	self name = anotherPackage name ifFalse: [ ^false ].
	self version = anotherPackage version ifFalse: [ ^false ].
	self category = anotherPackage category ifFalse: [ ^false ].
	self depends = anotherPackage depends ifFalse: [ ^false ].
	self provides = anotherPackage provides ifFalse: [ ^false ].
	self squeakMapID = anotherPackage squeakMapID ifFalse: [ ^false ].
	self url asString = anotherPackage url asString ifFalse: [ ^false ].
	self maintainer = anotherPackage maintainer ifFalse: [ ^false ].
	self homepage isNil = anotherPackage homepage isNil ifFalse: [ ^false ].
	(self homepage isNil or: [ 
		self homepage toText = anotherPackage homepage toText]) ifFalse: [ ^false ].

	self description = anotherPackage description ifFalse:[ ^false ].

	^true
