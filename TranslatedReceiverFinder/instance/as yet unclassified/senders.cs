senders

	| m o |
	m _ SystemNavigation default allCallsOn: #translated.
	m _ m collect: [:e |
		e classIsMeta ifTrue: [
			(Smalltalk at: e classSymbol) class decompile: e methodSymbol.
		] ifFalse: [
			(Smalltalk at: e classSymbol) decompile: e methodSymbol.
		]
	].

	o _ SortedCollection new.
	m do: [:e | self searchMethodNode: e addTo: o].
	^ o.
