buildTestsList
	| column offset buttonRow |
	column _ AlignmentMorph newColumn hResizing: #spaceFill;
				 vResizing: #spaceFill;
				 layoutInset: 0;
				 borderWidth: 0;
				 borderColor: Color black;
				color: Color transparent;
				 layoutPolicy: ProportionalLayout new.
	testsList _ PluggableListMorphOfMany
				on: self
				list: #tests
				primarySelection: #selectedSuite
				changePrimarySelection: #selectedSuite:
				listSelection: #listSelectionAt:
				changeListSelection: #listSelectionAt:put:
				menu: #listMenu:shifted:.
	testsList autoDeselect: false.
	offset _ 0.
	self wantsOptionalButtons
		ifTrue: [offset _ TextStyle default lineGrid + 14 ].
	column
		addMorph: testsList
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 1 @ 1)
				offsets: (0 @ 0 corner: 0 @ offset negated)).
	self wantsOptionalButtons
		ifTrue: [buttonRow _ self optionalButtonRow.
			buttonRow
				color: (Display depth <= 8
						ifTrue: [Color transparent]
						ifFalse: [Color gray alpha: 0.2]);
				 borderWidth: 0.
			Preferences alternativeWindowLook
				ifTrue: [buttonRow color: Color transparent.
					buttonRow
						submorphsDo: [:m | m borderWidth: 1;
								 borderColor: #raised]].
			column
				addMorph: buttonRow
				fullFrame: (LayoutFrame
						fractions: (0 @ 1 corner: 1 @ 1)
						offsets: (0 @ (offset - 1) negated corner: 0 @ 0))].
	^ column