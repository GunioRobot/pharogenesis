testKindOfSubclass
	| classes d |
	classes := {self mockClassA. String. MethodContext. WeakArray. Float}.
	classes do: [:c |
		d :=  c asClassDefinition.
		self assert: d kindOfSubclass = c kindOfSubclass.
	].