colorPickerFor: target getter: getterSymbol setter: setterSymbol

	^ColorPickerMorph new
		initializeForPropertiesPanel;
		target: target;
		selector: setterSymbol;
		originalColor: (target perform: getterSymbol)