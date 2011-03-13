topBoundary

	^ (self splitterAbove ifNil: [self containingWindow panelRect top] ifNotNil: [self splitterAbove bottom]) + 75