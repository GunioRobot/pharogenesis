updatePointersInRootObjectsFrom: memStart to: memEnd 
	"update pointers in root objects"
	| oop |
	self inline: false.
	1 to: rootTableCount do: [:i | 
			oop _ rootTable at: i.
			(oop < memStart or: [oop >= memEnd])
				ifTrue: ["Note: must not remap the fields of any object twice!"
					"remap this oop only if not in the memory range 
					covered below"
					self remapFieldsAndClassOf: oop]]