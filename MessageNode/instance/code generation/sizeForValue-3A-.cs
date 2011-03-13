sizeForValue: encoder
	| total argSize |
	special > 0 
		ifTrue: [^self perform: (MacroSizers at: special) with: encoder with: true].
	receiver == NodeSuper
		ifTrue: [selector := selector copy "only necess for splOops"].
	total := selector size: encoder args: arguments size super: receiver == NodeSuper.
	receiver == nil 
		ifFalse: [total := total + (receiver sizeForValue: encoder)].
	sizes := arguments collect: 
					[:arg | 
					argSize := arg sizeForValue: encoder.
					total := total + argSize.
					argSize].
	^total