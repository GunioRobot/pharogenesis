setSelectedMorph: aMorph
	self selectedMorph: aMorph.
	self use: hitSelector orMakeModelSelectorFor: 'NewSelection:'
		in: [:sel | hitSelector _ sel.  model perform: sel with: selection]