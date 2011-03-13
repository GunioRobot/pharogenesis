sizeCodeForValue: encoder
	| total argSize |
	special > 0 
		ifTrue: [^self perform: (NewStyleMacroSizers at: special) with: encoder with: true].
	receiver == NodeSuper
		ifTrue: [selector := selector copy "only necess for splOops"].
	total := selector sizeCode: encoder args: arguments size super: receiver == NodeSuper.
	receiver == nil 
		ifFalse: [total := total + (receiver sizeCodeForValue: encoder)].
	sizes := arguments collect: 
					[:arg | 
					argSize := arg sizeCodeForValue: encoder.
					total := total + argSize.
					argSize].
	^total