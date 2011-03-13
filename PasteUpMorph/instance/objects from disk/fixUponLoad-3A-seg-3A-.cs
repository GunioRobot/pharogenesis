fixUponLoad: aProject seg: anImageSegment
	"We are in an old project that is being loaded from disk.
Fix up conventions that have changed."

	"Project loading obsolete. Remove dependency to sound system"
	"
	self isWorldMorph ifTrue: [
			(self valueOfProperty: #soundAdditions) ifNotNil:
				[:additions | SampledSound
assimilateSoundsFrom: additions]].
	"
	
	^ super fixUponLoad: aProject seg: anImageSegment