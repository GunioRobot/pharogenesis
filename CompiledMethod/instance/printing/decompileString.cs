decompileString
	| clAndSel cl sel |
	clAndSel _ self who.
	cl _ clAndSel first.
	sel _ clAndSel last.
	^ (cl decompilerClass new
			decompile: sel in: cl method: self) decompileString