image: aForm at: aPoint sourceRect: sourceRect rule: rule 
	"Draw the portion of the given Form defined by sourceRect at the given point using the given BitBlt combination rule."
	port isFXBlt 
		ifTrue:[port sourceKey: nil; sourceMap: nil; destMap: nil;
					colorMap: (aForm colormapIfNeededFor: form); fillPattern: nil]
		ifFalse:[port colorMap: (aForm colormapIfNeededForDepth: form depth); fillColor: nil].
	port image: aForm at: aPoint + origin sourceRect: sourceRect rule: rule.