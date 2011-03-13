bottomBoundary

	^ (self splitterBelow ifNil: [self containingWindow panelRect bottom] ifNotNil: [self splitterBelow top]) - 75