decodeCmapFmtTable: entry
	| cmapFmt length cmap firstCode entryCount segCount segments offset code |
	cmapFmt _ entry nextUShort.
	length _ entry nextUShort.
	entry skip: 2. "skip version"

	cmapFmt = 0 ifTrue: "byte encoded table"
		[length _ length - 6. 		"should be always 256"
		length <= 0 ifTrue: [^ nil].	"but sometimes, this table is empty"
		cmap _ Array new: length.
		entry nextBytes: length into: cmap startingAt: entry offset.
		^ cmap].

	cmapFmt = 4 ifTrue: "segment mapping to deltavalues"
		[segCount _ entry nextUShort // 2.
		entry skip: 6. "skip searchRange, entrySelector, rangeShift"
		segments _ Array new: segCount.
		segments _ (1 to: segCount) collect: [:e | Array new: 4].
		1 to: segCount do: [:i | (segments at: i) at: 2 put: entry nextUShort]. "endCount"
		entry skip: 2. "skip reservedPad"
		1 to: segCount do: [:i | (segments at: i) at: 1 put: entry nextUShort]. "startCount"
		1 to: segCount do: [:i | (segments at: i) at: 3 put: entry nextShort]. "idDelta"
		offset _ entry offset.
		1 to: segCount do: [:i | (segments at: i) at: 4 put: entry nextUShort]. "idRangeOffset"
		cmap _ Array new: 256 withAll: 0. "could be larger, but Squeak can't handle that"
		segments withIndexDo:
			[:seg :si |
			seg first to: seg second do:
				[:i |
				i < 256 ifTrue:
					[seg last > 0 ifTrue:
						["offset to glypthIdArray - this is really C-magic!"
						entry offset: i - seg first - 1 * 2 + seg last + si + si + offset. 
						code _ entry nextUShort.
						code > 0 ifTrue: [code _ code + seg third]]
					ifFalse:
						["simple offset"
						code _ i + seg third].
					cmap at: i + 1 put: code]]].
		^ cmap].

	cmapFmt = 6 ifTrue: "trimmed table"
		[firstCode _ entry nextUShort.
		entryCount _ entry nextUShort.
		cmap _ Array new: entryCount + firstCode withAll: 0.
		entryCount timesRepeat:
			[cmap at: (firstCode _ firstCode + 1) put: entry nextUShort].
		^ cmap].
	^ nil