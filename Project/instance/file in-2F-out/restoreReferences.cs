restoreReferences
	| key newKey extName |
	"I just came in from an exported segment.  Take all my players that were in References, and reinstall them."

	"*** Note that (world valueOfProperty: #References) is temporary during loading and is not the same as the global References dictionary (in Smalltalk)."
	(world valueOfProperty: #References ifAbsent: [#()]) do: [:assoc | "just came in"
		key _ assoc key.
		(References includesKey: key) 
			ifTrue: ["must rename" 
				extName _ assoc value externalName.	"what user sees"
				(References at: key) == assoc value ifTrue: [
					self error: 'why is this object already present?'].
				newKey _ assoc value uniqueNameForReference.
				References removeKey: newKey.
				assoc key: newKey.
				References add: assoc.	"use the known association"

				Preferences universalTiles
					ifTrue: [assoc value renameTo: newKey] 	"change names in scripts"
					ifFalse: [(assoc value renameInternal: extName)	"keep externalName the same"
								ifNil: [assoc value renameTo: newKey]].
									"rename Project itself.  Ignore others"
				]
			ifFalse: [References add: assoc]].
	world removeProperty: #References.