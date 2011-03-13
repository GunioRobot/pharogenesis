addButtonsAndFileListPanesTo: window at: upperFraction plus: offset forFileList: aFileList 
	| fileListMorph row buttonHeight fileListTop divider dividerDelta buttons |
	fileListMorph := PluggableListMorph
				on: aFileList
				list: #fileList
				selected: #fileListIndex
				changeSelected: #fileListIndex:
				menu: #fileListMenu:.
	fileListMorph enableDrag: true; enableDrop: false.
	aFileList wantsOptionalButtons
		ifTrue: [buttons := aFileList optionalButtonRow.
			divider := BorderedSubpaneDividerMorph forBottomEdge.
			dividerDelta := 0.
			buttons color: Color transparent.
					buttons
						submorphsDo: [:m | m borderWidth: 2;
								 borderColor: #raised].
divider extent: 4 @ 4;
						 color: Color transparent;
						 borderColor: #raised;
						 borderWidth: 2.
					fileListMorph borderColor: Color transparent.
					dividerDelta := 3.
			row := AlignmentMorph newColumn hResizing: #spaceFill;
						 vResizing: #spaceFill;
						 layoutInset: 0;
						 borderWidth: 2;
						 layoutPolicy: ProportionalLayout new.
			buttonHeight := self defaultButtonPaneHeight.
			row
				addMorph: buttons
				fullFrame: (LayoutFrame
						fractions: (0 @ 0 corner: 1 @ 0)
						offsets: (0 @ 0 corner: 0 @ buttonHeight)).
			row
				addMorph: divider
				fullFrame: (LayoutFrame
						fractions: (0 @ 0 corner: 1 @ 0)
						offsets: (0 @ buttonHeight corner: 0 @ buttonHeight + dividerDelta)).
			row
				addMorph: fileListMorph
				fullFrame: (LayoutFrame
						fractions: (0 @ 0 corner: 1 @ 1)
						offsets: (0 @ buttonHeight + dividerDelta corner: 0 @ 0)).
			window
				addMorph: row
				fullFrame: (LayoutFrame
						fractions: upperFraction
						offsets: (0 @ offset corner: 0 @ 0)).
			row borderWidth: 2]
		ifFalse: [fileListTop := 0.
			window
				addMorph: fileListMorph
				frame: (0.3 @ fileListTop corner: 1 @ 0.3)].