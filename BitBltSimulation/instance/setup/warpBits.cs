warpBits
	| ns |
	self inline: true.
	ns _ noSource.  noSource _ true.
		self clipRange.  "noSource suppresses sourceRect clipping"
		noSource _ ns.
	(noSource or: [bbW <= 0 or: [bbH <= 0]]) ifTrue:
		["zero width or height; noop"
		affectedL _ affectedR _ affectedT _ affectedB _ 0.
		^ nil].

 	self lockSurfaces.
	self destMaskAndPointerInit.
	self warpLoop.
 
	hDir > 0
		ifTrue: [affectedL _ dx.
				affectedR _ dx + bbW]
		ifFalse: [affectedL _ dx - bbW + 1.
				affectedR _ dx + 1].
	vDir > 0
		ifTrue: [affectedT _ dy.
				affectedB _ dy + bbH]
		ifFalse: [affectedT _ dy - bbH + 1.
				affectedB _ dy + 1].
	self unlockSurfaces.