reallyObsoleteMetaclasses
	^ Metaclass allInstances select: [:each | self isReallyObsolete: each].