addPanel: aMorph
	"Adds a new panel to the editor."

	(self tabsMorph) addTab: (ReferenceMorph forMorph: aMorph).
	(self pages) add: aMorph.