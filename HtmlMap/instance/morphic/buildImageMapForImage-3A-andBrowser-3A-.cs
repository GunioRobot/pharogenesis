buildImageMapForImage: imageMorph andBrowser: browser
	| areaMorph |
	contents do: [:area |
		(area isArea
		and: [(areaMorph _ area linkMorphForMap: self andBrowser: browser) isNil not])
			ifTrue: [imageMorph addMorph: areaMorph]].
	^imageMorph