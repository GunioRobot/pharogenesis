openInMVC
	| window extent |
	self localBounds: localBounds.
	extent _ bounds extent.
	window _ FlashPlayerWindow labelled:'Flash Player'.
	window model: (FlashPlayerModel player: self).
	window addMorph: self frame:(0@0 corner: 1@1).
	window openInMVCExtent: extent