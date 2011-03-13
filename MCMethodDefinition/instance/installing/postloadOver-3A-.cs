postloadOver: aDefinition
	super postloadOver: aDefinition.
	(self isInitializer
		and: [ self actualClass isTrait not ]
		and: [ aDefinition isNil or: [ self source ~= aDefinition source ] ]) ifTrue: [
			self actualClass theNonMetaClass initialize ]