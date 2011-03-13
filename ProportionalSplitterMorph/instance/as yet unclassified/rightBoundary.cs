rightBoundary

	^ (self splitterRight ifNil: [self containingWindow panelRect right] ifNotNil: [self splitterRight left]) - 50