lookupExternalDropHandler: stream

	| types extension serviceHandler |
	types _ stream mimeTypes.

	types ifNotNil: [
		self registeredHandlers do: [:handler | 
			(handler matchesTypes: types)
				ifTrue: [^handler]]].

	extension _ FileDirectory extensionFor: stream name.
	self registeredHandlers do: [:handler | 
		(handler matchesExtension: extension)
				ifTrue: [^handler]].
	serviceHandler := self lookupServiceBasedHandler: stream.
	^serviceHandler
		ifNil: [self defaultHandler]