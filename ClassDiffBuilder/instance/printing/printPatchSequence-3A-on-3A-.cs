printPatchSequence: ps on: aStream 
	| type line |
	ps do: [:assoc | 
			type := assoc key.
			line := assoc value.
			aStream
				withAttributes: (self attributesOf: type)
				do: [aStream nextPutAll: line]]