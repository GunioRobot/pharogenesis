postload
	(self isInitializer and: [ self actualClass isTrait not ]) ifTrue: [
		self actualClass theNonMetaClass initialize]