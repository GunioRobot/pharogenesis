paneForTabs: tabList 
	"Answer a pane bearing tabs for the given list"
	| aPane |
	tabList do: [:t |
			t color: Color transparent.
			t borderWidth: 1;
				borderColor: Color black].

	aPane := AlignmentMorph newRow
				listDirection: #leftToRight;
				wrapDirection: #topToBottom;
				vResizing: #spaceFill;
				hResizing: #spaceFill;
				cellInset: 6;
				layoutInset: 4;
				listCentering: #center;
				listSpacing: #equal;
				addAllMorphs: tabList;
				yourself.

	aPane width: self layoutBounds width.

	^ aPane