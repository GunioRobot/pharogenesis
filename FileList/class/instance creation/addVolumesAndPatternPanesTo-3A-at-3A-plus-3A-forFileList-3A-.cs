addVolumesAndPatternPanesTo: window at: upperFraction plus: offset forFileList: aFileList 
	| row patternHeight volumeListMorph patternMorph divider dividerDelta |
	row := AlignmentMorph newColumn hResizing: #spaceFill;
				 vResizing: #spaceFill;
				 layoutInset: 0;
				 borderWidth: 0;
				 layoutPolicy: ProportionalLayout new.
	patternHeight := 25.
	volumeListMorph := (PluggableListMorph
				on: aFileList
				list: #volumeList
				selected: #volumeListIndex
				changeSelected: #volumeListIndex:
				menu: #volumeMenu:)
				autoDeselect: false.
	volumeListMorph enableDrag: false; enableDrop: true.
	patternMorph := PluggableTextMorph
				on: aFileList
				text: #pattern
				accept: #pattern:.
	patternMorph acceptOnCR: true.
	patternMorph hideScrollBarsIndefinitely.
	divider := BorderedSubpaneDividerMorph horizontal.
	dividerDelta := 0.
	divider extent: 4 @ 4;
			color: Color transparent;
			borderColor: #raised;
			borderWidth: 2.
		volumeListMorph borderColor: Color transparent.
		patternMorph borderColor: Color transparent.
		dividerDelta := 3.
	row
		addMorph: (volumeListMorph autoDeselect: false)
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 1 @ 1)
				offsets: (0 @ 0 corner: 0 @ patternHeight negated - dividerDelta)).
	row
		addMorph: divider
		fullFrame: (LayoutFrame
				fractions: (0 @ 1 corner: 1 @ 1)
				offsets: (0 @ patternHeight negated - dividerDelta corner: 0 @ patternHeight negated)).
	row
		addMorph: patternMorph
		fullFrame: (LayoutFrame
				fractions: (0 @ 1 corner: 1 @ 1)
				offsets: (0 @ patternHeight negated corner: 0 @ 0)).
	window
		addMorph: row
		fullFrame: (LayoutFrame
				fractions: upperFraction
				offsets: (0 @ offset corner: 0 @ 0)).
	row borderWidth: 2