initFromPinSpecs
	outputSelector _ pinSpecs first modelWriteSelector.
	inputSelectors _ (pinSpecs copyFrom: 2 to: pinSpecs size)
						collect: [:ps | ps modelReadSelector]