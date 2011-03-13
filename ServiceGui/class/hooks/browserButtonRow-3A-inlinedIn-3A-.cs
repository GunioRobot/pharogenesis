browserButtonRow: aBrowser inlinedIn: row 
	| bar |
	self buttonBarServices 
		ifTrue: [bar _ (self new for: aBrowser id: #browserButtonBar) buildButtonBar.
			row addMorphBack: bar].
	^ row