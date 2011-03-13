asMorphicSyntaxUsing: aClass
	
	^ Cursor wait showWhile: [
		(aClass methodNodeOuter: self) finalAppearanceTweaks]
		