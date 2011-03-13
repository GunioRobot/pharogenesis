assert: alevel sendsIn: aSendInfo for: aSelector are: aCollectionOfSelectors
	| detectedSends message |
	detectedSends := aSendInfo perform: (alevel, 'SentSelectors') asSymbol.
	message := alevel, ' sends wrong for ', aSelector.
	self assert: ((detectedSends isEmpty and: [aCollectionOfSelectors isEmpty]) or:
				[detectedSends = (aCollectionOfSelectors asIdentitySet)]) description: message