addToFormatter: formatter
	| morph url |
	self src isNil ifTrue: [ ^self ].
	url _ self src.
	formatter baseUrl ifNotNil: [ 
		url _ url asUrlRelativeTo: formatter baseUrl ].


	morph _ DownloadingImageMorph new.
	morph defaultExtent: self imageExtent.
	morph altText: self alt.
	morph url: url.
	self imageMapName
		ifNotNil:
			[morph imageMapName: self imageMapName.
			morph formatter: formatter].

	formatter addIncompleteMorph: morph.