removeAllForFont: aFreeTypeFont
	| toRemove d |
	
	(fontTable includesKey: aFreeTypeFont) ifFalse:[^self].
	toRemove := IdentitySet new.
	fifo do:[:entry |
		entry font = aFreeTypeFont
			ifTrue:[toRemove add: entry]].
	toRemove do:[:entry | 
		fifo remove: entry.
		d := (fontTable at: entry font) at: entry charCode.
		d removeKey: entry type.	
		used := used - (self sizeOf: entry object) ]. 

	