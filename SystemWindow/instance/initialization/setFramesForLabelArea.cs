setFramesForLabelArea
	"an aid to converting old instances, but then I found  
	convertAlignment (jesse welton's note)"
	| frame windowBorderWidth |
	labelArea ifNil: [^ self].	
	labelArea
		layoutPolicy: TableLayout new;
		listDirection: #leftToRight;
		hResizing: #spaceFill;
		layoutInset: 0.
	label hResizing: #spaceFill.
	labelArea
		ifNotNil: [frame _ LayoutFrame new.
			frame leftFraction: 0;
				topFraction: 0;
				rightFraction: 1;
				topOffset: self labelHeight negated.
				windowBorderWidth := self class borderWidth.
			frame leftOffset: windowBorderWidth;
				rightOffset: windowBorderWidth negated;
				topOffset: self labelHeight negated + windowBorderWidth;
				bottomOffset: windowBorderWidth negated.
			labelArea layoutFrame: frame]