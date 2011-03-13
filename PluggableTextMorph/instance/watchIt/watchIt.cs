watchIt

	| result |
	
	self handleEdit:
		[result := textMorph editor compileSelectionAsBlock.
		((result isKindOf: FakeClassPool) or: [result == #failedDoit])
			ifTrue: [^self flash]].
	(RectangleMorph new)
		layoutPolicy: TableLayout new;
		layoutInset: 10;
		listDirection: #topToBottom;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		addMorphBack: (StringMorph contents: textMorph editor selection);
		addMorphBack: ((UpdatingStringMorph on: result selector: #value)
			stepTime: 500;
			maximumWidth: nil;			
			growable: true);
		color: Color white;
		borderColor: Color black;
		openInWindowLabeled: 'Watcher'.