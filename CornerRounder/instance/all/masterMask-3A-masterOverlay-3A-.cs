masterMask: maskForm masterOverlay: overlayForm

	cornerMasks _ #(none left pi right) collect:
		[:dir | (maskForm rotateBy: dir centerAt: 0@0) offset: 0@0].
	cornerOverlays _ #(none left pi right) collect:
		[:dir | (overlayForm rotateBy: dir centerAt: 0@0) offset: 0@0].
