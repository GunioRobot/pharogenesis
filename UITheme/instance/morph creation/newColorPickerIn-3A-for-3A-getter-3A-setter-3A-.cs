newColorPickerIn: aThemedMorph for: target getter: getterSymbol setter: setterSymbol
	"Answer a color picker for the given morph and accessors."

	^PanelMorph new
		borderStyle: (BorderStyle inset width: 1);
		fillStyle: Color white;
		changeTableLayout;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		addMorph: (ColorPickerMorph new
			initializeForPropertiesPanel;
			target: target;
			selector: setterSymbol;
			originalColor: (target perform: getterSymbol));
		yourself