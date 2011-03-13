restoreReferences
	| key newKey |
	"I just came in from an exported segment.  Take all my players that were in References, and reinstall them."

	(world valueOfProperty: #References ifAbsent: [#()]) do: [:assoc | "just came in"
		key _ assoc key.
		(References includesKey: key) 
			ifTrue: ["must rename" 
				(References at: key) == assoc value ifTrue: [
					self error: 'why object already present?'].
				newKey _ assoc value uniqueNameForReference.
				References removeKey: newKey.
				assoc key: newKey.
				References add: assoc.	"use the known association"
				assoc value renameTo: newKey.	"Player name and recompile scripts"
				]
			ifFalse: [References add: assoc]].
	world removeProperty: #References.