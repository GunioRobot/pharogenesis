makeThumbnailFor: proj

	(proj isNil or: [proj thumbnail isNil]) ifTrue: [
		^(StringMorph contents: '???') imageForm
	].
	^proj thumbnail
