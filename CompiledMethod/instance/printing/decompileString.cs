decompileString
	| clAndSel cl sel |
	clAndSel _ self who.
	clAndSel = #(unknown unknown)
		ifTrue:
			[cl _ Object.
			sel _ #xxxUnknown.
			self numArgs >= 1
				ifTrue:
					[sel _ sel , ':'.
					2 to: self numArgs do: [:i | sel _ sel , 'with:'].
					sel _ sel asSymbol]]
		ifFalse:
			[cl _ clAndSel first.
			sel _ clAndSel last].
	^ (cl decompilerClass new
			decompile: sel in: cl method: self) decompileString