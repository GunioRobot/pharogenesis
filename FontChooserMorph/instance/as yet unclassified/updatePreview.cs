updatePreview

	Cursor wait showWhile: 
		[
		self fontPreviewPanel
				hScrollBarValue: 0;
				vScrollBarValue: 0.
		self fontPreviewPanel scroller removeAllMorphs.
		self fontPreviewPanel scroller addMorphBack: self newFontPreviewInnerPanel]