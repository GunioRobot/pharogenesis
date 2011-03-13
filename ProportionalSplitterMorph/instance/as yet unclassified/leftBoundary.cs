leftBoundary

	^ (self splitterLeft ifNil: [self containingWindow panelRect left] ifNotNil: [self splitterLeft right]) + 50