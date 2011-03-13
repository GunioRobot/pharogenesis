ifInteractiveDo: aBlock
	self current isInteractive ifTrue: [aBlock value]