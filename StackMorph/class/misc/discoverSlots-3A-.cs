discoverSlots: aMorph
	"Examine the parts of the morph for ones that couldHoldSeparateData.  Return a pair of lists: Named morphs, and unnamed morphs (which may be labels, and non-data).  Examine all submorphs."

	| named unnamed got sn generic |
	named _ OrderedCollection new.
	unnamed _ OrderedCollection new.
	aMorph submorphsDo: [:direct | 
		got _ false.
		direct allMorphsDo: [:sub |
			sub couldHoldSeparateDataForEachInstance ifTrue: [
				(sn _ sub knownName) ifNotNil: [
					generic _ (#('Number (fancy)' 'Number (mid)' 'Number (bare)')
									includes: sn).
					(sn beginsWith: 'shared' "label") | generic ifFalse: [
						named add: sub.
						got _ true]]]].
		got ifFalse: [unnamed add: direct]].
	^ Array with: named with: unnamed
		