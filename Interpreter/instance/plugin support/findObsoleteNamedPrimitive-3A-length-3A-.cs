findObsoleteNamedPrimitive: functionName length: functionLength
	"Search the obsolete named primitive table for the given function.
	Return the index if it's found, -1 otherwise."
	| entry index chIndex |
	self var: #functionName type:'char *'.
	self var: #entry type:'const char *'.
	index _ 0.
	[true] whileTrue:[
		entry _ self
			cCode: 'obsoleteNamedPrimitiveTable[index][0]'
			inSmalltalk: [ (CArrayAccessor on: (obsoleteNamedPrimitiveTable at: index)) at: 0 ].
		entry == nil ifTrue:[^-1]. "at end of table"
		self cCode: '' inSmalltalk: [ entry _ CArrayAccessor on: entry ].
		"Compare entry with functionName"
		chIndex _ 0.
		[(entry at: chIndex) = (functionName at: chIndex) 
			and:[chIndex < functionLength]] whileTrue:[chIndex _ chIndex + 1].
		(chIndex = functionLength and:[(entry at: chIndex) = 0]) 
			ifTrue:[^index]. "match"
		index _ index + 1.
	].