compileAllAccessors

	info keys asArray do: [:k |
		(#(who x y heading color visible) includes: k) ifFalse: [
			self compileVectorInstVarAccessorsFor: k.
		].
	].
