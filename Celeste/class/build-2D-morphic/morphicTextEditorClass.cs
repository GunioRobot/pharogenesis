morphicTextEditorClass
	^ (self environment at: #MorphicTextEditor ifAbsent: [^ PluggableTextMorph]) default