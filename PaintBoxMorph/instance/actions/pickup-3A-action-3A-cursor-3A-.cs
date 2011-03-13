pickup: actionButton action: aSelector cursor: aCursor
	"Special version for pickup: and stamp:, because of these tests"

	| ss picker old map stamper |
	self tool: actionButton action: aSelector cursor: aCursor.

	aSelector == #stamp: ifTrue: [
		(stampHolder pickupButtons includes: actionButton) ifTrue: [
				stamper _ stampHolder otherButtonFor: actionButton.
				^ self pickup: stamper action: #stamp: cursor: (stamper arguments at: 3)].
		(stampHolder stampFormFor: actionButton) 
			ifNil: [
				"If not stamp there, go to pickup mode"
				picker _ stampHolder otherButtonFor: actionButton.
				picker state: #on.
				^ self pickup: picker action: #pickup: cursor: (picker arguments at: 3)]
			ifNotNil: [
				old _ stampHolder stampFormFor: actionButton.
				currentCursor _ ColorForm extent: old extent depth: 8.
				old displayOn: currentCursor.
				map _ Color indexedColors copy.
				map at: 1 put: Color transparent.
				currentCursor colors: map.
				currentCursor offset: currentCursor extent // 2.
				"Emphisize the stamp button"
				actionButton owner "layoutMorph" "color: (Color r: 1.0 g: 0.645 b: 0.419);"
					borderColor: (Color r: 0.65 g: 0.599 b: 0.8).
				]].

	aSelector == #pickup: ifTrue: [
		ss _ self world findA: SketchEditorMorph.
		ss ifNotNil: [currentCursor _ aCursor]	 
			ifNil: [self notCurrentlyPainting
				self setAction: #paint:]].
