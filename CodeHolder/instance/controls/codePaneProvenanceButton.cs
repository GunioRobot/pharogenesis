codePaneProvenanceButton
	"Answer a button that reports on, and allow the user to modify,
	the code-pane-provenance setting"
	
	^(UITheme builder
		newDropListFor: self
		list: #codePaneProvenanceList
		getSelected: #codePaneProvenanceIndex
		setSelected: #codePaneProvenanceIndex:
		help: 'Select what is shown in the code pane' translated)
			useRoundedCorners;
			hResizing: #spaceFill;
			vResizing: #spaceFill;
			minWidth: 88