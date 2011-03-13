adjustCurrentPageForFullScreen

	self isInFullScreenMode ifTrue: [
		(currentPage hasProperty: #sizeWhenNotFullScreen) ifFalse: [
			currentPage setProperty: #sizeWhenNotFullScreen toValue: currentPage extent.
		].
		currentPage extent: Display extent.
	] ifFalse: [
		(currentPage hasProperty: #sizeWhenNotFullScreen) ifTrue: [
			currentPage extent: (currentPage valueOfProperty: #sizeWhenNotFullScreen).
			currentPage removeProperty: #sizeWhenNotFullScreen.
		].
	].