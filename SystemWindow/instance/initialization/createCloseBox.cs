createCloseBox
	^ self createBox labelGraphic: self class closeBoxImage;
		 extent: self boxExtent;
		 actionSelector: #closeBoxHit;
		 setBalloonText: 'close this window' translated