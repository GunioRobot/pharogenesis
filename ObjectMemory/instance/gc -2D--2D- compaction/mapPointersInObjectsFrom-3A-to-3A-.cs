mapPointersInObjectsFrom: memStart to: memEnd
	"Use the forwarding table to update the pointers of all non-free objects in the given range of memory. Also remap pointers in root objects which may contains pointers into the given memory range."

	| oop |
	self inline: false.
	self compilerMapHookFrom: memStart to: memEnd.
	"update interpreter variables"
	self mapInterpreterOops.

	"update pointers in root objects"
	1 to: rootTableCount do: [ :i | 
		oop _ rootTable at: i.
		((oop < memStart) or: [oop >= memEnd]) ifTrue: [
			"Note: must not remap the fields of any object twice!"
			"remap this oop only if not in the memory range covered below"
			self remapFieldsAndClassOf: oop.
		].
	].

	"update pointers in the given memory range"
	oop _ self oopFromChunk: memStart.
	[oop < memEnd] whileTrue: [
		(self isFreeObject: oop) ifFalse: [
			self remapFieldsAndClassOf: oop.
		].
		oop _ self objectAfterWhileForwarding: oop.
	].