installTextualCodingPane
	"Install text into the code pane"

	| aWindow codePane aPane boundsToUse |
	(aWindow _ self containingWindow) ifNil: [self error: 'where''s that window?'].
	codePane _ aWindow findDeepSubmorphThat:   
		[:m | ((m isKindOf: PluggableTextMorph) and: [m getTextSelector == #contents]) or:
			[m isKindOf: PluggableTileScriptorMorph]] ifAbsent: [self error: 'no code pane'].
	aPane _ self buildMorphicCodePaneWith: nil.
	boundsToUse _ (codePane bounds origin- (1@1)) corner: (codePane owner bounds corner " (1@1").
	aWindow replacePane: codePane with: aPane.
	aPane vResizing: #spaceFill; hResizing: #spaceFill; borderWidth: 0.
	aPane bounds: boundsToUse.
	aPane owner clipSubmorphs: false.

	self contentsChanged