generateCodeStringForPrimitives
	| s methodList |
	s _ ReadWriteStream on: (String new: 1000).
	methodList _ methods asSortedCollection: [:m1 :m2 | m1 selector < m2 selector].
	self emitCHeaderForPrimitivesOn: s.
	self emitCVariablesOn: s.
	self emitCFunctionPrototypes: methodList on: s.
	methodList do: [:m | m emitCCodeOn: s generator: self].
	^ s contents
