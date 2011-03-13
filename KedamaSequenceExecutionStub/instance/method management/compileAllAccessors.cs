compileAllAccessors

	turtles info keys asArray do: [:k |
		(#(who x y heading color visible normal) includes: k) ifFalse: [
			self compileScalarInstVarAccessorsFor: k.
		].
	].
