createCollapseBox
	^ self createBox labelGraphic: self class collapseBoxImage;
		 extent: self boxExtent;
		 actionSelector: #collapseOrExpand;
		 setBalloonText: 'collapse this window' translated.
