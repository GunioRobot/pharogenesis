checkTableSelectors: anArray
	| selectors cls missing |
	selectors _ IdentitySet new.
	cls _ DynamicInterpreter.
	[cls == Object] whileFalse:
		[selectors addAll: cls selectors.
		cls _ cls superclass].
	missing _ anArray reject: [:sel | selectors includes: sel].
	missing isEmpty ifFalse:
		[Transcript cr; show: 'The following table selectors are undefined: '; tab.
		(IdentitySet new addAll: missing; yourself) do: [:sel | Transcript space; nextPutAll: sel].
		Transcript cr; endEntry.
		self halt.]