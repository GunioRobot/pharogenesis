setTempNamesIfCached: aBlock
	"This is a cache used by the debugger, independent of the storage of
	temp names when the system is converted to decompilation with temps."
	TempNameCache == nil ifTrue: [^self].
	TempNameCache key == self
		ifTrue: [aBlock value: TempNameCache value]